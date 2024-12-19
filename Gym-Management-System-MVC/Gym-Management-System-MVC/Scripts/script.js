//login Button target
function loginPage() {
    window.location.href = "login.html"
}

document.querySelectorAll(".sideButton").forEach((e) => {
    e.classList.remove("active")
})

if (document.getElementById("form-add-coach")) {
    document.querySelector(".sideButton[target='coaches']").classList.add('active');

    displayForm("form-add-coach", "btn-close-coach", "coachform");
}else if (document.getElementById("form-add-plan")) {
    document.querySelector(".sideButton[target='plan']").classList.add('active');

    displayForm("form-add-plan", "btn-close-plan", "planform");
}else if (document.getElementById("form-add-equipment")) {
    document.querySelector(".sideButton[target='Inventory']").classList.add('active');

    displayForm("form-add-equipment", "btn-close-Inventory", "Inventoryform");
}else if (document.getElementById("edit-profile-button")) {
    document.querySelector(".sideButton[target='Admin-profile']").classList.add('active');

    displayForm("edit-profile-button", "cancel-edit", "profile-edit-form");
} else if (document.getElementById("dashHome")) {
    document.querySelector(".sideButton[target='dashHome']").classList.add('active');
} else if (document.getElementById("regeteration")) {
    document.querySelector(".sideButton[target='regeteration']").classList.add('active');
} else if (document.getElementById("payment")) {
    document.querySelector(".sideButton[target='payment']").classList.add('active');
} else if (document.getElementById("viewMembers")) {
    document.querySelector(".sideButton[target='viewMembers']").classList.add('active');
} else if (document.getElementById("report")) {
    document.querySelector(".sideButton[target='report']").classList.add('active');
}


//chartes
if (document.getElementById('salesChart')) {
    var ctx = document.getElementById('salesChart').getContext('2d');

    var data = {
        datasets: [{
            data: [84, 16], // النسبة المئوية للمبيعات والباقي
            backgroundColor: ['#1a1363', '#E0E0E0'], // الألوان
            borderWidth: 0
        }],
    };

    var options = {
        plugins: {
            tooltip: { enabled: true }, // تعطيل التولتيب
            legend: { display: true }, // إخفاء الـ Legend
        },
        cutout: '70%', // لجعل الرسم على شكل دائرة مفرغة
    };

    new Chart(ctx, {
        type: 'doughnut',
        data: data,
        options: options,
    });

    var calendar = document.getElementById("calendar");
    var monthYear = document.getElementById("monthYear");
    var daysContainer = document.getElementById("daysContainer");

    var today = new Date();
    var currentMonth = today.getMonth();
    var currentYear = today.getFullYear();

    var months = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
    ///calender funcation
    function createCalendar(month, year) {

        var firstDay = new Date(year, month, 1).getDay();
        var lastDate = new Date(year, month + 1, 0).getDate();

        monthYear.innerHTML = `${months[month]} ${year}`;
        daysContainer.innerHTML = `
            <div>Sun</div>
            <div>Mon</div>
            <div>Tue</div>
            <div>Wed</div>
            <div>Thu</div>
            <div>Fri</div>
            <div>Sat</div>
        `;

        for (let i = 0; i < firstDay; i++) {
            daysContainer.innerHTML += `<div></div>`;
        }

        for (let i = 1; i <= lastDate; i++) {
            daysContainer.innerHTML += `<div>${i}</div>`;
        }
    }

    createCalendar(currentMonth, currentYear);

}

function displayForm(displayButtonId, closeButtonId, formClass) {
    var displayButton = document.getElementById(displayButtonId);
    var closeButton = document.getElementById(closeButtonId);
    var form = document.getElementsByClassName(formClass)[0];

    displayButton.addEventListener("click", () => {
        form.style.display = form.style.display === "flex" ? "none" : "flex";
        formClass == "profile-edit-form" ? form.style.display = "block" : "none"
    });

    closeButton.addEventListener("click", () => {
        form.style.display = "none";
    });
}




