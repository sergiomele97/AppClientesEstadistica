namespace ApiBasesDeDatosProyecto.Utilidades
{
    public static class Extensiones
    {


        public static bool ComprobarEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Expresión regular para validar el formato del email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
