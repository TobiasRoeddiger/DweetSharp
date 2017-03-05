using System;
using System.Threading.Tasks;

#pragma warning disable RECS0143 // Cannot resolve symbol in text argument

namespace DweetSharp
{
    public static class Dweet
    {
        private static DweetSharpHttpClient _dweetIOClient = new DweetSharpHttpClient();

        ///LOCKS
        public static async Task<bool> Lock(string thing, string dweetLock, string masterKey) {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentNullException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(dweetLock)) { throw new ArgumentNullException("dweetLock can't be null or empty"); }
            if (string.IsNullOrEmpty(masterKey)) { throw new ArgumentNullException("masterKey can't be null or empty"); }

            var uri = string.Format("https://dweet.io/lock/{0}?lock={1}&key={2}", thing, dweetLock, masterKey);
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        public static async Task<bool> Unlock(string thing, string masterKey)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentNullException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(masterKey)) { throw new ArgumentNullException("masterKey can't be null or empty"); }

            var uri = string.Format("https://dweet.io/unlock/{0}?key={1}", thing, masterKey);
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        public static async Task<bool> RemoveLock(string dweetLock, string masterKey)
        {
            if (string.IsNullOrEmpty(dweetLock)) { throw new ArgumentNullException("dweetLock can't be null or empty"); }
            if (string.IsNullOrEmpty(masterKey)) { throw new ArgumentNullException("masterKey can't be null or empty"); }

            var uri = string.Format("https://dweet.io/remove/lock/{0}?key={1}", dweetLock, masterKey);;
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        ///DWEETS
        public static async Task<bool> DweetFor(string thing, string JSONcontent, string key = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentNullException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(JSONcontent)) { throw new ArgumentNullException("JSONcontent can't be null or empty"); }

            string uri = string.Format("https://dweet.io/dweet/for/{0}", thing) + ((key == null) ? "?key=" + key : null);
            return await _dweetIOClient.POSTWithDidSucceedReturned(uri, JSONcontent);
        }

        public static async Task<bool> DweetQuietlyFor(string thing, string JSONcontent, string key = null)
        {
            string uri = string.Format("https://dweet.io/dweet/quietly/for/{0}", thing) + ((key == null) ? "?key=" + key : null);
            return await _dweetIOClient.POSTWithDidSucceedReturned(uri, JSONcontent);
        }

        public static async Task<string> GetLatestDweetFor(string thing, string key = null)
        {
            string uri;

            if (key == null)
            {
                uri = string.Format("https://dweet.io/get/latest/dweet/for/{0}", thing);
            }
            else {
                uri = string.Format("https://dweet.io/get/latest/dweet/for/{0}?key={1}", thing, key);
            }
            return await _dweetIOClient.GETWithContentReturned(uri);
        }

        public static async Task<string> GetDweetsFor(string thing, string key = null)
        {
            throw new NotImplementedException();
        }

        public static async Task<bool> ListenForDweetsFrom(string thing, string key = null)
        {
            throw new NotImplementedException();
        }

        ///STORAGE
        public static async Task<string> GetStoredDweetsFor(string thing, string key, string date, string hour = null, string responseType = null)
        {
            throw new NotImplementedException();
        }

        public static async Task<string> GetStoredAlertsFor(string thing, string key, string date, string hour = null, string responseType = null)
        {
            throw new NotImplementedException();
        }

        ///ALERTS
        public static async Task<bool> Alert(string who, string thing, string condition, string key)
        {
            throw new NotImplementedException();
        }

        public static async Task<string> GetAlertFor(string thing, string key)
        {
            throw new NotImplementedException();
        }

        public static async Task<string> RemoveAlertFor(string thing, string key)
        {
            throw new NotImplementedException();
        }
    }
}
