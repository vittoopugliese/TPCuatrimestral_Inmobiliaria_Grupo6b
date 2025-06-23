<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="customize.css" />  <%-- linkea a la clase para el formato borde sombreado del contenedor del form  --%>

    <style>

        body::before {
            content: '';
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-image: url('pictures/fondoDefault.png');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            filter: blur(5px);
            z-index: -1;
        }

    </style>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; padding: 15px;">
            <div align="center" class="container bg-light boxshadow col-12 col-sm-8 col-md-6 col-lg-4 col-xl-3" style="border-radius: 15px; padding: 0; max-width: 400px;">
                <div>
                        <div class="text-white rounded-top d-flex align-items-center justify-content-center" style="padding: 15px; background-color: #121212;">
                            <h2 class="mb-0">Registrarse</h2>
                        </div>
                    
                    <div class="px-4 py-4">
                        <div class="form-group mb-3">

                            <asp:Label ID="LabelMensaje" runat="server" Text="" Visible="false" CssClass="alert alert-dismissible"></asp:Label>

                            <label class="text-dark form-label" for="emailLabel">Correo Electronico</label>
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">@</div>
                                </div>
                                <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control" placeholder="Ingrese un correo electronico"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group mb-4">
                            <label class="text-dark form-label" for="contraLabel">Contraseña</label>
                            <asp:TextBox ID="TextBoxContra" runat="server" CssClass="form-control" placeholder="Ingrese una contraseña" TextMode="Password"></asp:TextBox>
                        </div>
                        <asp:RegularExpressionValidator 
                            ID="revPassword" 
                            runat="server"
                            ControlToValidate="TextBoxContra"
                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^\s]{8,}$"
                            ErrorMessage="Requiere 8 caracteres, una mayúscula, una minúscula y un número"
                            Display="Dynamic"
                            CssClass="text-danger">
                        </asp:RegularExpressionValidator>
                  
                             <asp:Button ID="ButtonRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary w-100" BackColor="#121212" OnClick="ButtonRegistrar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

        <script>
            document.addEventListener("keydown", function (event) {
                if (event.key === "Escape") {
                    location.replace("Login.aspx");
                }
            });
        </script>

</body>
</html>