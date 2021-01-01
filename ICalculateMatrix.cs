using System.Collections.Generic;

namespace KararVerme
{
    public interface ICalculateMatrix
    {
        List<ResultAlternaive> GetBestAlternative(List<Criterion> criterions, List<Alternative> alternatives);
    }
}
