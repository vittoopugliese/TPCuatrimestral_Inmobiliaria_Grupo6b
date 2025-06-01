<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InmuebleSeleccionado.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.InmuebleSeleccionado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="margin-top: 5rem">


        <div class="card">
            <div class="card-body">
                <h4 class="card-title">Casa en Venta en Avellaneda</h4>
                <p class="card-text">25 de Mayo 1350, Avellaneda</p>
                <div class="row">
                    <div class="col-8">

                        <asp:Image ID="Image1" runat="server"
                            ImageUrl="https://tse3.mm.bing.net/th/id/OIP.YecF78KPK1f4B3Cu6Qj3BAHaFF?rs=1&pid=ImgDetMain"
                            Width="100%" CssClass="rounded" />
                    </div>
                    <div class="col-4">

                        <div class="card">
                            <div class="card-body">

                                <label for="inputEmail4" class="form-label">CONTACTAR AL PROPIETARIO</label>
                                <input type="text" class="form-control" id="nombreyapellido" placeholder="Nombre y Apellido" style="margin-top: 10px">
                                <input type="email" class="form-control" id="email" placeholder="Email" runat="server" style="margin-top: 10px">
                                <input type="tel" class="form-control" id="telefono" runat="server" placeholder="Teléfono" style="margin-top: 10px">
                                <textarea class="form-control" id="exampleFormControlTextarea1" runat="server" placeholder="Mensaje..." rows="3" style="margin-top: 10px"></textarea>
                                <div class="form-check form-switch">
                                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" runat="server" style="margin-top: 15px">
                                    <label class="form-check-label" for="flexSwitchCheckDefault" style="margin-top: 10px">Recibir copia por email</label>
                                </div>
                                <asp:Button Text="Contactar" CssClass="btn btn-dark" ID="btnContactar" runat="server" Style="width: 100%; margin-top: 10px" OnClick="btnContactar_Click"/>
                                <asp:Button Text="Enviar Whastapp" CssClass="btn btn-success" ID="Button1" runat="server" Style="width: 100%; margin-top: 10px" />
                            </div>
                        </div>

                        <div class="card" style="margin-top: 17px">
                            <div class="card-body">
                                <p>Nombre del Propietario</p>
                                <p>Teléfono (011) 4263-5632</p>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h2 style="margin-top: 15px">U$D 110.000</h2>
        <p>$40.000 de expensas</p>
        <p>Publicado el 01/06/2025</p>
        <hr />

        <h2 style="margin-top: 15px">VENTA DE CASA EN AVELLANEDA, excelente !</h2>
        <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
    </div>



</asp:Content>
