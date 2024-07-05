using UPC.PMS.DA;

namespace UPC.PMS.BL;

public class ReleaseBL
{
    public IEnumerable<ReleaseModel.ListarPorProyecto> ListarPorProyecto(int id_proyecto){
        try
        {
            var releaseDA = new ReleaseDA();
            return releaseDA.ListarPorProyecto(id_proyecto);
            
        }
        catch (Exception)
        {
            throw;
        }
    }
}
