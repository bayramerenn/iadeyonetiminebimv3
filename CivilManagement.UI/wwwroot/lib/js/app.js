const tbody = document.getElementsByClassName("data")[0];
const inputBarcode = document.getElementById("barcode");
const saveButton = document.getElementById("saveproducts");
const store = document.getElementById("store");
const invoiceDate = document.getElementById("invoiceDate");
const addButton = document.getElementById("addsku");



let ui = new UI();
let request = new Request();

eventListeners();

function eventListeners() {
    inputBarcode.addEventListener("keydown", searchProduct)
    saveButton.addEventListener("click", saveProduct)
    addButton.addEventListener("click", addProduct)
}

function searchProduct(e) {
    if (e.keyCode == 13 && e.target.value != "") {
        const barcode = e.target.value;
        let element, product;

        var item = {
            "Barcode": barcode
        };
       // console.log(invoiceDate.textContent);

        request.Post("Return/GetBarcode", item).then(data => {
            for (let index = 0; index < tbody.children.length; index++) {
                const getSku = tbody.children[index].children[0].textContent.trim();

                element = tbody.children[index];
                // console.log(getSku)

                if (getSku === data.sku) {
                    product = new Product(
                        Sku = tbody.children[index].children[0].textContent,
                        Description = tbody.children[index].children[1].textContent,
                        Color = tbody.children[index].children[2].textContent,
                        ItemDim1Code = tbody.children[index].children[3].textContent,
                        CreatedDate = tbody.children[index].children[4].textContent,
                        CreatedUserName = tbody.children[index].children[5].textContent,
                        Qty1 = tbody.children[index].children[6].textContent,
                        qty2 = Number(tbody.children[index].children[7].textContent) + 1
                    );

                    break;
                }
            }

            //Kayıtları eklendiği yer
            if (product != undefined) {
                ui.setTable(product, element);
            } else {
                ui.alertError("Bu ürün iade listenizde mevcut değildir.!")
            }
        }).catch(err =>
            ui.alertError("Barkod sistemde kayıtlı değil.! Ürün Planlama ile görüşüp güncellenmesini sağlayabilirsiniz!")
        );
        e.target.value = "";
    }
}

function addProduct() {
    console.log("ekle")
    let selectedProduct = document.getElementsByClassName("select2-selection__rendered")[0].getAttribute("title");
    let productList = Array.from(document.getElementsByClassName("form-control select2 select2-hidden-accessible")[0])
    let element, product, tbodySku, StopIteration;

    for (var i = 0; i < productList.length; i++) {
        if (productList[i].textContent === selectedProduct) {
            for (let index = 0; index < tbody.children.length; index++) {
                const getSku = tbody.children[index].children[0].textContent;

                element = tbody.children[index];

                if (getSku === productList[i].getAttribute("value")) {
                    product = new Product(
                        Sku = tbody.children[index].children[0].textContent,
                        Description = tbody.children[index].children[1].textContent,
                        Color = tbody.children[index].children[2].textContent,
                        ItemDim1Code = tbody.children[index].children[3].textContent,
                        CreatedDate = tbody.children[index].children[4].textContent,
                        CreatedUserName = tbody.children[index].children[5].textContent,
                        Qty1 = tbody.children[index].children[6].textContent,
                        qty2 = Number(tbody.children[index].children[7].textContent) + 1
                    );

                    break;
                }
            }
            if (product != undefined) {
                ui.setTable(product, element);
            } else {
                ui.alertError("Bu ürün iade listenizde mevcut değildir.!")
            }
            selectedProduct.textContent = "";

            break;
        }
    }
}

function saveProduct() {
    let product = [];
    let value = 0;

    for (let index = 0; index < tbody.children.length; index++) {

        let s2 = Number(tbody.children[index].children[7].textContent)
        let date =tbody.children[index].children[4].textContent;
        console.log(s2);

        if (s2 !== 0) {
            product.push({
                "SKU" : tbody.children[index].children[0].textContent,
                "Description" : tbody.children[index].children[1].textContent,
                "ColorCode" : tbody.children[index].children[2].textContent,
                "ItemDim1Code" : tbody.children[index].children[3].textContent,
                "CreatedDate": invoiceDate.textContent,
                "CreatedUserName" : tbody.children[index].children[5].textContent,
                "StoreCode": store.textContent,
                "ReturnQty" : Number(tbody.children[index].children[7].textContent) 
                
            });
            console.log(product)
        }
        //else {
        //    ui.alertError("Okutulmamış ürünler bulunmaktadır.")
        //    value = 1;
        //}
    }
    if (value === 0) {
       
        request.PostProduct("Return/AddProduct", product)
            .then(data => {
               // tbody.remove()
                let timerInterval
                Swal.fire({
                    title: 'Kayıt ediliyor lütfen bekleyiniz!',
                    html: '<b></b> Milisaniye sonra kapanacaktır.',
                    timer: 3000,
                    timerProgressBar: true,
                    onBeforeOpen: () => {
                        Swal.showLoading()
                        timerInterval = setInterval(() => {
                            const content = Swal.getContent()
                            if (content) {
                                const b = content.querySelector('b')
                                if (b) {
                                    b.textContent = Swal.getTimerLeft()
                                }
                            }
                        }, 100)
                    },
                    onClose: () => {
                        clearInterval(timerInterval)
                    }
                }).then((result) => {
                    /* Read more about handling dismissals below */
                    if (result.dismiss === Swal.DismissReason.timer) {
                        console.log('I was closed by the timer')
                        window.location.assign(window.location.href);
                    }
                })
            });

        
    }
}