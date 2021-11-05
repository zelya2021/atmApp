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
        if (this.currentOperandTextElement.innerText.length < 19) {
            this.currentOperandTextElement.innerText += this.currentOperand.toString().substr(this.currentOperand.toString().length - 1)
        }
        else {
            return
        }

        if (this.currentOperandTextElement.innerText.length == 4) {
            this.currentOperandTextElement.innerText += "-";
        }
        if (this.currentOperandTextElement.innerText.length == 9) {
            this.currentOperandTextElement.innerText += "-";
        }
        if (this.currentOperandTextElement.innerText.length == 14) {
            this.currentOperandTextElement.innerText += "-";
        }
        localStorage.clear()
        localStorage.setItem('cardNumberSt', currentOperandTextElement.innerText)
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
    atm.clear()
    atm.updateDisplay()
})

const atmForm = document.querySelector('#atm-form');

if (atmForm) {
    atmForm.addEventListener('submit', SendCardNumber);
}

function SendCardNumber(e) {
    e.preventDefault();
    const cardNumber = currentOperandTextElement.innerText;
    $.ajax({
        type: "post",
        url: "/Home/GetCardNumber",
        data: {
            cardNumber: cardNumber
        },
        success: function (response) {
            window.location.href = response.redirectToUrl;
        }
    })
}
////for Pin Page
//const numberPinButtons = document.querySelectorAll('[pin-number]')
//const allClearPinButton = document.querySelector('[pin-all-clear]')
//const currentOperandPinTextElement = document.querySelector('[pin-current-operand]')

//const calculatorForPin = new Atm(currentOperandPinTextElement)

//numberPinButtons.forEach(button => {
//    button.addEventListener('click', () => {
//        calculatorForPin.appendNumber(button.innerText)
//        calculatorForPin.updatePinDisplay()
//    })
//})

//allClearPinButton.addEventListener('click', button => {
//    calculatorForPin.clear()
//    calculatorForPin.updatePinDisplay()
//})