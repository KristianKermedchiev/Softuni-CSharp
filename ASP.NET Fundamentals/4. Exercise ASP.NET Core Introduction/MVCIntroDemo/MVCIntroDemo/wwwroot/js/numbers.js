function SetLimit() {

    let num = document.getElementById("limitInput").value;

    window.location = "https://localhost:7275/Numbers/Limit?num=" + num;
}