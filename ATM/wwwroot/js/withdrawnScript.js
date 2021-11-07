const withdrawnAmount = document.querySelector('#withdrawnAmount');
const amount = document.querySelector('#amount');

const redirectTo = document.querySelector('#redirectTo');

if (withdrawnAmount) {
    withdrawnAmount.addEventListener('submit', SendAmount);
}

function SendAmount(e) {
    e.preventDefault();
    const cardNumber = localStorage.getItem('cardNumberSt')
    console.log(cardNumber)
    $.ajax({
        type: "post",
        url: "/Home/Withdrawal",
        data: {
            cardNumber: cardNumber,
            withdrawnAmount: amount.value
        },
        success: function (response) {
            window.location.href = response.redirectToUrl;
        }
    })
}

if (redirectTo) {
    redirectTo.addEventListener('click', redirectToOperations);
}

function redirectToOperations() {
    $.ajax({
        type: "post",
        data: {
            cardNumber: localStorage.getItem('cardNumberSt'),
        },
        url: "/Home/RedirectOperations",
        success: function (response) {
            window.location.href = response.redirectToUrl;
        }
    });
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