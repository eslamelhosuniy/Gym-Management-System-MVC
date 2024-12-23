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


function filterRows(event) {
    const select = event.target; 
    const value = select.value; 
    const table = select.closest('.controls').nextElementSibling; 
    const rows = table.getElementsByTagName('tr'); 
    let count = 0; 
    for (let i = 1; i < rows.length; i++) { 
        if (value === "all") {
            rows[i].style.display = ''; 
        } else if (count < parseInt(value)) {
            rows[i].style.display = ''; 
            count++;
        } else {
            rows[i].style.display = 'none'; 
        }
    }
}

function searchTable(event) {
    const input = event.target; 
    const filter = input.value.toLowerCase(); 
    const table = input.closest('.controls').nextElementSibling; 
    const rows = table.getElementsByTagName('tr'); 

    for (let i = 1; i < rows.length; i++) { 
        const cells = rows[i].getElementsByTagName('td');
        let match = false;

        for (let j = 0; j < cells.length; j++) {
            if (cells[j]) {
                const cellValue = cells[j].textContent || cells[j].innerText;
                if (cellValue.toLowerCase().indexOf(filter) > -1) {
                    match = true;
                    break;
                }
            }
        }

        rows[i].style.display = match ? '' : 'none'; 
    }
}



    // استهداف كل أزرار Edit
    const editCoaches = document.querySelectorAll(".editCoach");

    // إضافة حدث click لكل زر
    editCoaches.forEach((button) => {
      button.addEventListener("click", function () {
        // الحصول على الصف الحالي
        const row = this.closest("tr");

        // استخراج البيانات من الأعمدة
        const name = row.children[0].textContent.trim();
        const phone = row.children[1].textContent.trim();
        const Specialty = row.children[2].textContent.trim();
        const email = row.children[3].textContent.trim();

        // ملء الحقول في الفورم
        document.getElementById("newCoach-name").value = name;
        document.getElementById("newcoach-phone").value = phone;
        document.getElementById("newcoach-Specialty").value = Specialty;
        document.getElementById("newcoach-Email").value = email;
      });
    });
    const editplans = document.querySelectorAll(".editCoach");

    // إضافة حدث click لكل زر
    editplans.forEach((button) => {
      button.addEventListener("click", function () {
        // الحصول على الصف الحالي
        const row = this.closest("tr");

        // استخراج البيانات من الأعمدة
        const name = row.children[0].textContent.trim();
        const Validity = row.children[1].textContent.trim();
        const Amount = row.children[2].textContent.trim();

        // ملء الحقول في الفورم
        document.getElementById("newplan-name").value = name;
        document.getElementById("newplan-Validity").value = Validity;
        document.getElementById("newplan-Amount").value = Amount;
      });
    });

