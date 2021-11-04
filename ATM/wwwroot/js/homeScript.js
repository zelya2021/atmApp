class Atm {
    constructor(currentOperandTextElement) {
        this.currentOperandTextElement = currentOperandTextElement
        this.clear()
    }

    clear() {
        this.currentOperand = ''
        this.currentOperandTextElement.innerText = ''
    }

    delete() {
        this.currentOperand = this.currentOperand.toString().slice(0, -1)
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

    }
}


const numberButtons = document.querySelectorAll('[data-number]')
const allClearButton = document.querySelector('[data-all-clear]')
const currentOperandTextElement = document.querySelector('[data-current-operand]')

const calculator = new Atm(currentOperandTextElement)

numberButtons.forEach(button => {
    button.addEventListener('click', () => {
        calculator.appendNumber(button.innerText)
        calculator.updateDisplay()
    })
})

allClearButton.addEventListener('click', button => {
    calculator.clear()
    calculator.updateDisplay()
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
        success: function () {
            currentOperandTextElement.innerText=""
        }
    })
}