class Atm {
    constructor(currentOperandTextElement) {
        this.currentOperandTextElement = currentOperandTextElement
        this.clear()
    }

    clear() {
        this.currentOperand = ''
        this.currentOperandTextElement.innerText = ''
    }

    appendNumber(number) {
        this.currentOperand = this.currentOperand.toString() + number.toString()
    }

    updateDisplay() {
        if (this.currentOperandTextElement.innerText.length < 4) {
            this.currentOperandTextElement.innerText += "*"
        }
        else {
            return
        }
    }

    getCurrentPassword() {
        return this.currentOperand.substr(0,4).toString();
    }
}


const numberButtons = document.querySelectorAll('[data-number]')
const allClearButton = document.querySelector('[data-all-clear]')
const currentOperandTextElement = document.querySelector('[data-current-operand]')

const atm = new Atm(currentOperandTextElement)

numberButtons.forEach(button => {
    button.addEventListener('click', () => {
        atm.appendNumber(button.innerText)
        atm.updateDisplay()
    })
})

allClearButton.addEventListener('click', button => {
    atm.updateDisplay()
    atm.clear()
    
    
})

const atmForm = document.querySelector('#atm-form');

if (atmForm) {
    atmForm.addEventListener('submit', SendCardNumber);
}

function SendCardNumber(e) {
    e.preventDefault();
    const pin = atm.getCurrentPassword();
    $.ajax({
        type: "post",
        url: "/Home/PinCodeEnter",
        data: {
            cardNumber: localStorage.getItem('cardNumberSt'),
            pin: pin
        },
        success: function (response) {
            window.location.href = response.redirectToUrl;
        }
    })
}

const redirectTo = document.querySelector('#thirdBtn');
if (redirectTo) {
    redirectTo.addEventListener('click', redirectToIndex);
}

function redirectToIndex() {
    $.ajax({
        type: "post",
        data: {
            cardNumber: localStorage.getItem('cardNumberSt'),
        },
        url: "/Home/RedirectIndex",
        success: function (response) {
            window.location.href = response.redirectToUrl;
        }
    });
}