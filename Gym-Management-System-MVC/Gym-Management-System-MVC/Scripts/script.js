//login Button target
function loginPage() {
    window.location.href = "login.html"
}


//chartes
const ctx = document.getElementById('salesChart').getContext('2d');

        const data = {
            datasets: [{
                data: [84, 16], // النسبة المئوية للمبيعات والباقي
                backgroundColor: ['#1a1363', '#E0E0E0'], // الألوان
                borderWidth: 0
            }],
        };

        const options = {
            plugins: {
                tooltip: { enabled: true }, // تعطيل التولتيب
                legend: { display: true}, // إخفاء الـ Legend
            },
            cutout: '70%', // لجعل الرسم على شكل دائرة مفرغة
        };

        new Chart(ctx, {
            type: 'doughnut',
            data: data,
            options: options,
        });
        
    const calendar = document.getElementById("calendar");
    const monthYear = document.getElementById("monthYear");
    const daysContainer = document.getElementById("daysContainer");

    const today = new Date();
    const currentMonth = today.getMonth();
    const currentYear = today.getFullYear();

    const months = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
///calender funcation
    function createCalendar(month, year) {
        
        const firstDay = new Date(year, month, 1).getDay();
        const lastDate = new Date(year, month + 1, 0).getDate();

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

//activate sections
let buttons = document.querySelectorAll(".sideButton");
let sections = document.querySelectorAll(".section");

buttons.forEach(button => {
    button.addEventListener("click", function () {
        sections.forEach(section => section.classList.remove("active"));
        
        buttons.forEach(btn => btn.classList.remove("active"));

        let targetid = button.getAttribute("target");
        
        let targetsection = document.getElementById(targetid);
        
        targetsection.classList.add("active");
        
        button.classList.add("active");
    });
});


function displayForm(displayButtonId, closeButtonId, formClass) {
    const displayButton = document.getElementById(displayButtonId);
    const closeButton = document.getElementById(closeButtonId);
    const form = document.getElementsByClassName(formClass)[0];

    displayButton.addEventListener("click", () => {
        form.style.display = form.style.display === "flex" ? "none" : "flex";
        formClass == "profile-edit-form" ? form.style.display = "block" : "none"
    });

    closeButton.addEventListener("click", () => {
        form.style.display = "none";
    });
}

displayForm("form-add-plan", "btn-close-plan", "planform");
displayForm("form-add-coach", "btn-close-coach", "coachform");
displayForm("form-add-equipment", "btn-close-Inventory", "Inventoryform");
displayForm("edit-profile-button", "cancel-edit", "profile-edit-form");


