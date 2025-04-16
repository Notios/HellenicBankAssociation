// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const filterInput = document.getElementById('filterInput');
const banksList = document.getElementById('banksList');

async function fetchBanks(filter = '') {
    const response = await fetch(`https://localhost:7069/Home/banks?startsWith=${filter}`);
    const banks = await response.json();
        
    banksList.innerHTML = '';

    banks.forEach(bank => {
        const listItem = document.createElement('li');
        listItem.classList.add('list-group-item');
        listItem.textContent = bank;
        banksList.appendChild(listItem);
    });
}

fetchBanks();

filterInput.addEventListener('input', (event) => {
    const filterValue = event.target.value;
    fetchBanks(filterValue);
});