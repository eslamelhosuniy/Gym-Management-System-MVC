//login Button target
function loginPage() {
    window.location.href = "login.html"
}

document.addEventListener("DOMContentLoaded", () => {
    // إزالة الـ active من جميع الأزرار الجانبية
    document.querySelectorAll(".sideButton").forEach((e) => {
        e.classList.remove("active");
    });

    // التحقق من العناصر وإضافة الـ active بناءً على الحالة
    if (document.getElementById("form-add-coach")) {
        const sideButton = document.querySelector(".sideButton[target='coaches']");
        if (sideButton) {
            sideButton.classList.add('active');
        }
        displayForm("form-add-coach", "btn-close-coach", "coachform");

    } else if (document.getElementById("form-add-plan")) {
        const sideButton = document.querySelector(".sideButton[target='plan']");
        if (sideButton) {
            sideButton.classList.add('active');
        }
        displayForm("form-add-plan", "btn-close-plan", "planform");

    } else if (document.getElementById("form-add-equipment")) {
        const sideButton = document.querySelector(".sideButton[target='Inventory']");
        if (sideButton) {
            sideButton.classList.add('active');
        }
        displayForm("form-add-equipment", "btn-close-Inventory", "Inventoryform");

    } else if (document.getElementById("edit-profile-button")) {
        const sideButton = document.querySelector(".sideButton[target='Admin-profile']");
        if (sideButton) {
            sideButton.classList.add('active');
        }
        displayForm("edit-profile-button", "cancel-edit", "profile-edit-form");

    } else if (document.getElementById("dashHome")) {
        const sideButton = document.querySelector(".sideButton[target='dashHome']");
        if (sideButton) {
            sideButton.classList.add('active');
        }

    } else if (document.getElementById("regeteration")) {
        const sideButton = document.querySelector(".sideButton[target='regeteration']");
        if (sideButton) {
            sideButton.classList.add('active');
        }

    } else if (document.getElementById("payment")) {
        const sideButton = document.querySelector(".sideButton[target='payment']");
        if (sideButton) {
            sideButton.classList.add('active');
        }

    } else if (document.getElementById("viewMembers")) {
        const sideButton = document.querySelector(".sideButton[target='viewMembers']");
        if (sideButton) {
            sideButton.classList.add('active');
        }

    } else if (document.getElementById("report")) {
        const sideButton = document.querySelector(".sideButton[target='report']");
        if (sideButton) {
            sideButton.classList.add('active');
        }
    }
});



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

// دالة لملء الحقول في الفورم بناءً على البيانات
function fillForm(buttonClass, formData) {
    const buttons = document.querySelectorAll(buttonClass);

    buttons.forEach((button) => {
        button.addEventListener("click", function () {
            // الحصول على الصف الحالي
            const row = this.closest("tr");

            // استخراج البيانات من الأعمدة
            const data = Array.from(row.children).map(cell => cell.textContent.trim());

            // ملء الحقول في الفورم
            data.forEach((value, index) => {
                if (formData[index]) {
                    document.getElementById(formData[index]).value = value;
                }
            });
        });
    });
}

// استدعاء الدالة لكل نوع من الفورم

fillForm(".editCoach", ["newCoach-name", "newcoach-phone", "newcoach-Specialty", "newcoach-Email"]);
fillForm(".editplans", ["newplan-name", "newplan-Validity", "newplan-Amount"]);
fillForm(".EditMemper", ["EditMember-name", "EditMember-EmailAddress", "EditMember-ContactNo", "EditMember-adress"]);
fillForm(".Editequipment", ["EditEquipment-name", "EditEquipment-Totalno", "EditEquipment-Status"]);
