using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Data.Migrations.Employee
{
    /// <inheritdoc />
    public partial class AddTestEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "insert into Employees (name, surname, specialization) values ('Philippe', 'Ralphs', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Loutitia', 'Leuchars', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Jackie', 'Burridge', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Lulu', 'Weathey', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Octavius', 'Outlaw', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Terencio', 'Haydock', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Aidan', 'Huntington', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Louella', 'Adamowicz', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Webb', 'Debling', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Euell', 'Gianolini', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Eden', 'Lukash', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Remington', 'MacKettrick', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Culver', 'Dorgan', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Agnes', 'La Grange', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Jennine', 'McGregor', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Bethina', 'Caban', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Cal', 'Silveston', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Dorie', 'Lattimer', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Deloria', 'Puddifer', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Dodie', 'Kubach', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Theresita', 'Ackenhead', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Terrye', 'Boake', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Friedrick', 'Champley', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Jo-anne', 'Lackie', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Micky', 'Robinet', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Leanora', 'Lathan', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Joe', 'Colhoun', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Antonetta', 'Kleinstern', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Kaspar', 'Leverton', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Ali', 'Emons', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Chrystel', 'Sisley', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Harv', 'Porteous', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Gracie', 'Bode', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Joanie', 'Gillespie', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Gifford', 'Ivermee', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Lauretta', 'Redwood', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Lorenzo', 'Mackleden', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Rayna', 'Sawbridge', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Camila', 'Fluger', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Marci', 'Runnett', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Luce', 'Evetts', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Devlin', 'Lotze', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Meaghan', 'Heck', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Rickie', 'Twitching', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Caspar', 'Fawckner', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Margarete', 'Virgo', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Andreas', 'Lago', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Ernestine', 'Rydzynski', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Patrica', 'Speedin', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Karyl', 'Le Estut', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Sula', 'O''Gormally', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Jamie', 'Basterfield', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Giusto', 'Fawssett', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Ludovika', 'Heyball', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Dur', 'Hutchinson', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Terrijo', 'Heino', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Dorthy', 'Maasz', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Klemens', 'Pygott', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Maxie', 'Dougill', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Hube', 'Abrey', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Lorilyn', 'Gyngell', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Kenton', 'Whitlaw', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Clevie', 'Horsburgh', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Stevy', 'Rumbelow', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Titos', 'Eary', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Marcile', 'Fidele', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Giselle', 'Mannooch', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Quincey', 'Greatbatch', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Isidro', 'Retter', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Mariann', 'Garling', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Carmencita', 'Bonifas', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Bancroft', 'Lowcock', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Payton', 'Trathen', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Ellynn', 'Shieber', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Michelina', 'Dyer', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Corliss', 'Lean', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Sydel', 'Duer', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Fayette', 'Lowey', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Marylee', 'Barwood', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Row', 'Jemmison', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Lemar', 'McNerlin', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Prince', 'Byrcher', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Blinnie', 'Dizlie', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Fraze', 'Kuhlen', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Candi', 'Wanstall', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Brunhilda', 'Kirsopp', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Tim', 'Glasscoo', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Stacia', 'Sedgefield', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Eimile', 'Stilliard', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Alain', 'Balogh', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Marlena', 'Fyall', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Berni', 'Loudwell', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Marshall', 'Nacey', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Corliss', 'Buttriss', 'Shampoo master');" +
                "insert into Employees (name, surname, specialization) values ('Aeriell', 'Yurenev', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Reggi', 'Couling', 'Hairdresser');" +
                "insert into Employees (name, surname, specialization) values ('Thor', 'Beels', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Antonino', 'Ofer', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Fee', 'Jedrzejczak', 'Barber');" +
                "insert into Employees (name, surname, specialization) values ('Carver', 'Cann', 'Shampoo master');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Employees");
        }
    }
}
