namespace BackendEstadistica.Models
{
    public class ClienteConBalance
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public double Balance { get; set; }
        public int NumeroGastos { get; set; }
        public int NumeroIngresos { get; set; }
    }

}
