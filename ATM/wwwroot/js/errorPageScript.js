const redirectTo = document.querySelector('#thirdBtn');

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