using Prueba_Técnica;

Console.Write("Ingrese la Placa: ");
int placa = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

Console.Write("Ingrese la fecha tal y como está en el ejemplo (MM-DD-YYYY): ");
string fecha = Console.ReadLine();

Console.WriteLine();

Console.Write("Ingrese la hora tal y como está en el ejemplo (00:00) o (23:59): ");
string hora = Console.ReadLine();

Console.WriteLine();

try
{
    Console.WriteLine(Sistema.PredictorPyP(placa, fecha, hora));
}catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}