using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chinook.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryKeyGeneratedOnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TrackId",
                table: "Track",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "PlaylistId",
                table: "Playlist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "MediaTypeId",
                table: "MediaType",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceLineId",
                table: "InvoiceLine",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceId",
                table: "Invoice",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "GenreId",
                table: "Genre",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Customer",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "ArtistId",
                table: "Artist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "AlbumId",
                table: "Album",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TrackId",
                table: "Track",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "PlaylistId",
                table: "Playlist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "MediaTypeId",
                table: "MediaType",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceLineId",
                table: "InvoiceLine",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceId",
                table: "Invoice",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "GenreId",
                table: "Genre",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeId",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "Customer",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "ArtistId",
                table: "Artist",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<long>(
                name: "AlbumId",
                table: "Album",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
