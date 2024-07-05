namespace UPC.PMS.DA;

public class ReleaseModel
{
    public class ListarPorProyecto{
        public int id_release { get; set; }
        public string nombre  { get; set; } = string.Empty;
        public string fecha_inicio { get; set; } = string.Empty;
        public string fecha_final { get; set; } = string.Empty;
    }
}
