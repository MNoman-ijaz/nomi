let num1=8;
let num2=10;
document.getElementById("num1-el").textContent=num1;
document.getElementById("num2-el").textContent=num2;

let Sumel= document.getElementById("sum-el");
function add()
{
Sumel.textContent=num1+num2;
}
let Subel= document.getElementById("sub-el");
function sub()
{
    Subel.textContent=num1-num2;
}
let Mulel= document.getElementById("mul-el");
function mul()
{
    Mulel.textContent=num1*num2;
}
let Divel= document.getElementById("div-el")
 function divide()
 {
    Divel.textContent=num1/num2;
 }