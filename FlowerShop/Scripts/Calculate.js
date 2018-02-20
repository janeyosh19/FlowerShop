function Calcualte() {
    var selectedflower = document.getElementById("pieces").value;
    var value = parseInt(selectedflower);
    var prices =  document.getElementById("price").value;
    var price = parse.Float(prices);

    cost = price* value;


    document.getElementById("TotalPrice").innerHTML = cost;
}
