<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicarInmueble.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.PublicarInmueble" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container" style="margin-top: 4rem ">


        <div class="text-center">
  <h1>Nombre, empecemos a crear tu aviso!</h1>
</div>
        

        <div class="card shadow-lg mx-auto w-50" style="margin-top: 25px; padding: 20px; align-items: center">
            <div class="card-body">

                <label for="inputState" class="form-label" style="margin-top: 15px">Tipo de Operación</label>

                <form>
                    <div>
<div class="btn-group" role="group" aria-label="Basic radio toggle button group">
  <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" checked>
  <label class="btn btn-outline-dark" for="btnradio1">Vender</label>

  <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off">
  <label class="btn btn-outline-dark" for="btnradio2">Alquilar</label>

</div>
                    </div>



                            <div>
                            <label for="inputState" class="form-label" style="margin-top: 15px">Tipo de Propiedad</label>
                            <select id="TipoProp" class="form-select">
                                <option selected>Selecciona el tipo de propiedad</option>
                                <option>Casa</option>
                                <option>Departamento</option>
                                <option>PH</option>
                                <option>Local</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputAddress" class="form-label" style="margin-top: 15px">Ingresá calle y altura</label>
                            <input type="text" class="form-control" id="direccionSeleccionada" placeholder="Ingresá una dirección...">
                        </div>
                        <div>
                            <label for="inputAddress2" class="form-label" style="margin-top: 15px">Ingresá la Localidad</label>
                            <input type="text" class="form-control" id="localidadSeleccionada" placeholder="Ingresá la Localidad...">
                        </div>
                        <div>
                            <label for="inputState" class="form-label" style="margin-top: 15px">Seleccioná la Provincia</label>
                            <select id="idProvinciaSeleccionada" class="form-select" >
                                <option selected >Buenos Aires</option>
                                <option>Córdoba</option>
                                <option>Mendoza</option>
                                <option>San Luis</option>
                                <option>San Juan</option>
                            </select>
                        </div>

                        <div>
                                <label type="text" class="form-label" style="margin-top: 15px">Ingresá las Imágenes</label>
                            <div class="input-group">

                                <input type="file" class="form-control" id="inputGroupFile04" aria-describedby="inputGroupFileAddon04" aria-label="Upload">
                            </div>
 
                                <asp:Button Text="Guardar y Publicar"  CssClass="btn btn-dark" ID="btnGuardarPublicacion" runat="server" OnClick="btnGuardarPublicacion_Click" style="margin-top: 35px; width:500px"/>
                                
                        </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
