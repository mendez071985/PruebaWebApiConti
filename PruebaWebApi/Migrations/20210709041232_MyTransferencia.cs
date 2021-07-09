using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaWebApi.Migrations
{
    public partial class MyTransferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Ocupacion = table.Column<string>(nullable: true),
                    TipoDocumento = table.Column<string>(nullable: true),
                    Codigo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoCliente = table.Column<double>(nullable: false),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    Cuenta = table.Column<string>(nullable: true),
                    Sucursal = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudTransferencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreBeneficiario = table.Column<string>(nullable: true),
                    CuentaBeneficiario = table.Column<string>(nullable: true),
                    DocumentoBeneficiario = table.Column<string>(nullable: true),
                    NombreRemitente = table.Column<string>(nullable: true),
                    CuentaRemitente = table.Column<string>(nullable: true),
                    DocumentoRemitente = table.Column<string>(nullable: true),
                    Monto = table.Column<double>(nullable: false),
                    Motivo = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudTransferencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "SolicitudTransferencias");
        }
    }
}
