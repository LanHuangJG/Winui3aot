using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winui3aot.Model
{
    public record DownloadTaskCollection(
        List<DownloadTask> Running,
        List<DownloadTask> Finished    
    );

}
