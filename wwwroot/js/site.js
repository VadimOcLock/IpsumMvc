// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function burgerMenu() {
    const menu = document.querySelector("#menu")
    const burger = document.querySelector(".burger")

    burger.addEventListener("click", () => {
        burger.classList.toggle("active")
        menu.classList.toggle("hidden")
        menu.classList.toggle("flex")
    })
}
burgerMenu()

//Dark mode.

if (localStorage.theme === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
    document.documentElement.classList.add('dark')
} else {
    document.documentElement.classList.remove('dark')
}

const modeButton = document.querySelector("#mode")

modeButton.addEventListener("click", () => {
    document.querySelector("html").classList.toggle("dark")

    if (document.querySelector("html").classList.contains("dark")) {
        localStorage.theme = "dark"
    }
    else {
        localStorage.theme = "light"
    }
})