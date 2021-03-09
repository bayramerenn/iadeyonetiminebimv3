

class UI {

    setTable(product, element) {

        if (product.Qty1 == product.Qty2) {

            var table = this.getElemet("table-success", product);
            element.remove()
            this.setTbodyChild(table);
        }
        else if (Number(product.Qty1) > product.Qty2) {

            var table = this.getElemet("table-warning", product);
            element.remove()
            this.setTbodyChild(table);
        }
        else if (Number(product.Qty1) < product.Qty2) {

            setTimeout(() => {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Sistem fazla giriş miktarına izin vermez!',
                })
            }, 0);

        }
    }

    getElemet(className, product) {

        var table = document.createElement("tr");
        table.className = className;
        table.innerHTML +=
            `<td scope="row">${product.SKU}</td>
              <td>${product.Description}</td>
              <td>${product.ColorCode}</td>
              <td>${product.ItemDim1Code}</td>
              <td>${product.CreatedDate}</td>
              <td>${product.CreatedUserName}</td>
              <td>${product.Qty1}</td>
              <td>${product.Qty2}</td>`

        return table;
    }

    setTbodyChild(table) {

        const tbody = document.getElementsByClassName("data")[0];
        tbody.insertBefore(table, tbody.childNodes[0])
    }

    alertError(text) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: text

        })
    }


}