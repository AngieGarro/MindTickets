const receiptTemplate = `
<html>
<head>
<meta charset="UTF-8">
<title>Factura Electrónica Costa Rica</title>
<style>/*--- Actualizado: Abril 9, 2022 v3---*/

/* Atributos globales */

body {
    margin: 0;
    padding: 0;
    font-size: 16px;
    font-weight: 300;
    width: 100%;
    background: rgb(204, 204, 204);
}

hr {
    margin-top: 25px;
    margin-bottom: 25px;
}

h2,
h4,
p {
    margin: 0;
}

.page {
    background: #fff;
    display: block;
    margin: 3rem auto 3rem auto;
    position: relative;
    box-shadow: 0 0 0.5cm rgba(0, 0, 0.1);
}

.page[size='A4'] {
    width: 21cm;
    height: 29.7cm;
    overflow-x: hidden;
}


/* Sección Superior */

.cabecera {
    color: #fff;
    padding: 20px;
    height: 100px;
    background-color: #000;
}

.cabecera .fecha,
.cabecera .consecutivo {
    width: 50%;
    height: 100%;
    float: right;
}

.cabecera .consecutivo-electronico {
    max-width: 275px;
}

.fecha .fecha-emision {
    max-width: 240px;
    float: right;
    margin-top: 10px;
}


/* Segunda sección */

.fecha-emision .emision,
.fecha-emision .clave {
    display: block;
}

.fecha-emision .emision span,
.fecha-emision .clave span {
    float: right;
    margin-left: 30px;
}


/* Información del emisor */

.emisor {
    padding: 20px;
    font-size: 20px;
    margin-bottom: 15px;
}

.emisor .titulo {
    font-weight: 400;
    float: left;
}

.titulo .emisor-datos {
    font-size: 15px;
}

.factura .factura-info {
    font-weight: 400;
    text-align: right;
}

.factura .factura-datos {
    font-size: 15px;
}


/* Billing to */

.cliente {
    padding: 20px;
}

.cliente .titulo-cliente {
    font-weight: 400;
    font-size: 20px;
    margin-bottom: 7px;
}

.cliente .cliente-sec {
    width: 50%;
    float: left;
    font-size: 18px;
    margin-bottom: 25px;
    display: block;
}

.cliente .sub-titulo,
.cliente .nombre {
    font-weight: 400;
    font-size: 18px;
    margin-bottom: 5px;
}


/* Tabla */

.tabla {
    padding: 0 20px;
}

.tabla table {
    width: 100%;
}

.tabla table,
th,
td {
    padding: 5px;
    text-align: center;
    border: 1px solid #616161;
    border-collapse: collapse;
}


/* Calculo */

.calculo .calculo-total {
    margin-top: 25px;
    margin-bottom: 25px;
    width: 25%;
    position: absolute;
    right: 10px;
}

.calculo .total {
    font-weight: bold;
}


/* Pie de Página */

.pie .pie-pagina {
    padding: 15px;
    margin-top: 300px;
    margin-bottom: 25px;
    width: 75%;
}


/*Agregar todo entre un NAV y usar Flex*/
</style>
    

</head>
<body>
    <div class="page" size='A4'>
        <!-- Cabecera -->
        <div class="cabecera">
            <div class="Consecutivo">
                <div class="consecutivo-electronico">
                    <p> Consecutivo electrónico </p>
                    <p> ${random_number}</p>
                </div>
            </div>
            <div class="fecha">
                <div class="fecha-emision">
                    <div class="emision"> Fecha: <span class="span"> ${date}</span></div>
                    <div class="clave"> Clave numérica: <span class="span">${random_number} </span></div>
                </div>
            </div>
        </div>

        <!-- Información vendor -->
        <div class="emisor">
            <div>
            <img src="https://res.cloudinary.com/csalazarg/image/upload/v1692422675/MindTickets/Logotipo_MindsTickets_aohfnz.png" alt="devminds-logo" width="100" height="100">
        </div>
            <div class="titulo">
                DevMinds
                <p class="emisor-datos">Cédula: 3-101-598612</p>
                <p class="emisor-datos">Dirección: Alajuela, Grecia</p>
                <p class="emisor-datos">Teléfono: 6478-8712</p>
                <p class="emisor-datos">Correo: info@devminds.com</p>
            </div>


            <div class="factura">
                <div class="factura-info">
                    Factura electrónica
                    <p class="factura-datos">${receipt_number}</p>
                    <p class="factura-datos">Código: ${secuence_number}</p>
                    <p class="factura-datos">Término de pago: Contado</p>
                    <p class="factura-datos">Método de pago: ${payment_method}</p>
                    <p class="factura-datos">CRC-Colón</p>
                </div>
            </div>
        </div>

        <!-- Información Cliente -->
        <div class="cliente">
            <div class="titulo-cliente">Cliente: ${buyer}
                <p>Céd: ${user_id}</p>
                <p>Teléfono: ${user_phone}</p>
            </div>
        </div>



        <hr>

        <!-- Tabla -->
        <div class="tabla">
            <table>
                <tr>
                    <th> Código </th>
                    <th> Detalle </th>
                    <th> Cantidad </th>
                    <th> Precio Unitario </th>
                    <th> IVA </th>
                    <th> Descuentos </th>
                    <th> Total </th>
                </tr>
                <tr>
                    <td>${memb_id}</td>
                    <td>Membresía ${memb_title}</td>
                    <td>1</td>
                    <td>${price}</td>
                    <td>${tax}</td>
                    <td>0.0</td>
                    <td>${final_price}</td>
                </tr>
             

            </table>
        </div>

        <hr>

        <!-- Calculo -->
        <div class="calculo">
            <div class="calculo-total">
                <p> Total gravado: ₡${price}</p>
                <p> Subtotal: ₡${price}</p>
                <p> Descuento: ₡0</p>
                <p> IVA 13%: ₡${tax_applied}</p>
                <p class="total">Total: ₡${final_price}</p>
            </div>
        </div>

        <!-- Pie de página-->
        <div class="pie">
            <div class="pie-pagina">
                <p> Documento creado por El Bazar de las Sorpresas.</p>
                <p> Autorizada mediante la resolución No. DGT-R-033-2019 del 20 de Junio del 2019.</p>
                <p> Versión 4.3 de "Anexos y estructuras de los documentos electrónicos.</p>
            </div>
        </div>


    </div>

</body>

</html>`;


function getEmailTemplate(random_number, date, random_number, receipt_number, secuence_number, payment_method, buyer, user_id, user_phone, memb_id, memb_title, price, tax, final_price) {
    return receiptTemplate;
}
 