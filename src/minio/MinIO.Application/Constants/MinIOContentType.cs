using System.ComponentModel;

namespace MiniIO.Applcation;

enum MinIOContentType
{
    Default = 0,

    [Description("application/octet-stream")]
    OctetStream = 1
}