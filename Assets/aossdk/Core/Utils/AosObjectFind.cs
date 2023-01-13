using System.Linq;

namespace AosSdk.Core.Utils
{
    public static class AosObjectFind
    {
        public static AosObjectBase FindAosObjectById(string guid) => AosObjectBase.AosObjects.FirstOrDefault(aosObject => aosObject.ObjectId == guid);
    }
}