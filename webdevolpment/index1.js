let countEl = document.getElementById("count-el");
let saveEl= document.getElementById("save-el");
let count= 0;

function increment()
{
     count+=1;
    countEl.innerText =count;

}
function save()
{
    let countStr=count + "-";
    saveEl.textContent +=countStr;
    countEl.textContent=0;
    count=0;
}

// Function for decrement
function decrement() 
{
    if(count>0){
        count--;
        countEl.innerText =count;
    }  
}

