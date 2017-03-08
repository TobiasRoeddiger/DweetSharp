using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#pragma warning disable RECS0143 // Cannot resolve symbol in text argument

namespace DweetSharp
{
    public static class DweetIO
    {
        private static DweetSharpHttpClient _dweetIOClient = new DweetSharpHttpClient();

        ///LOCKS
        public static async Task<bool> Lock(string thing, string dweetLock, string masterKey) {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(dweetLock)) { throw new ArgumentException("dweetLock can't be null or empty"); }
            if (string.IsNullOrEmpty(masterKey)) { throw new ArgumentException("masterKey can't be null or empty"); }

            var uri = string.Format("https://dweet.io/lock/{0}?lock={1}&key={2}", thing, dweetLock, masterKey);
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        public static async Task<bool> Unlock(string thing, string masterKey)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(masterKey)) { throw new ArgumentException("masterKey can't be null or empty"); }

            var uri = string.Format("https://dweet.io/unlock/{0}?key={1}", thing, masterKey);
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        public static async Task<bool> RemoveLock(string dweetLock, string masterKey)
        {
            if (string.IsNullOrEmpty(dweetLock)) { throw new ArgumentException("dweetLock can't be null or empty"); }
            if (string.IsNullOrEmpty(masterKey)) { throw new ArgumentException("masterKey can't be null or empty"); }

            var uri = string.Format("https://dweet.io/remove/lock/{0}?key={1}", dweetLock, masterKey);;
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        ///DWEETS
        public static async Task<bool> DweetFor(string thing, string JSONcontent, string key = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(JSONcontent)) { throw new ArgumentException("JSONcontent can't be null or empty"); }
            if (key != null && key == string.Empty) { throw new ArgumentException("key can't be an empty string"); }

            string uri = string.Format("https://dweet.io/dweet/for/{0}", thing) + ((key != null) ? "?key=" + key : null);
            return await _dweetIOClient.POSTWithDidSucceedReturned(uri, JSONcontent);
        }

        public static async Task<bool> DweetQuietlyFor(string thing, string JSONcontent, string key = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(JSONcontent)) { throw new ArgumentException("JSONcontent can't be null or empty"); }
            if (key != null && key == string.Empty) { throw new ArgumentException("key can't be an empty string"); }

            string uri = string.Format("https://dweet.io/dweet/quietly/for/{0}", thing) + ((key != null) ? "?key=" + key : null);
            return await _dweetIOClient.POSTWithDidSucceedReturned(uri, JSONcontent);
        }

        public static async Task<string> GetLatestDweetFor(string thing, string key = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (key != null && key == string.Empty) { throw new ArgumentException("key can't be an empty string"); }

            string uri = string.Format("https://dweet.io/get/latest/dweet/for/{0}", thing) + ((key != null) ? "?key=" + key : null);
            return await _dweetIOClient.GETWithContentReturned(uri);
        }

        public static async Task<string> GetDweetsFor(string thing, string key = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (key != null && key == string.Empty) { throw new ArgumentException("key can't be an empty string"); }

            string uri = string.Format("https://dweet.io/get/latest/dweets/for/{0}", thing) + ((key != null) ? "?key=" + key : null);
            return await _dweetIOClient.GETWithContentReturned(uri);
        }

        public static async Task<bool> ListenForDweetsFrom(string thing, string key = null)
        {
            throw new NotImplementedException();
        }

        ///STORAGE
        public static async Task<string> GetStoredDweetsFor(string thing, string key, string date, string hour = null, string responseType = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(key)) { throw new ArgumentException("key can't be null or empty"); }
            //should replace houer.Length and date.Length with regex check
            if (date == null || date.Length != 10) { throw new ArgumentException("date should be a string in the format YYYY-MM-DD"); }
            if (hour != null && hour.Length != 2) { throw new ArgumentException("hour should be a string between 00 and 23"); }
            if (responseType != null && !(responseType == "json" || responseType == "csv")) { throw new ArgumentException("responseType must be json or csv"); }

            string uri = string.Format("https://dweet.io/get/stored/dweets/for/{0}?key={1}?date={2}", thing, key, date) 
                               + ((hour != null) ? "?hour=" + hour : null)
                               + ((responseType != null) ? "?responseType=" + responseType : null);
            return await _dweetIOClient.GETWithContentReturned(uri);
        }

        public static async Task<string> GetStoredAlertsFor(string thing, string key, string date, string hour = null, string responseType = null)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(key)) { throw new ArgumentException("key can't be null or empty"); }
            //should replace houer.Length and date.Length with regex check
            if (date == null || date.Length != 10) { throw new ArgumentException("date should be a string in the format YYYY-MM-DD"); }
            if (hour != null && hour.Length != 2) { throw new ArgumentException("hour should be a string between 00 and 23"); }
            if (responseType != null && !(responseType == "json" || responseType == "csv")) { throw new ArgumentException("responseType must be json or csv"); }

            string uri = string.Format("https://dweet.io/get/stored/alerts/for/{0}?key={1}?date={2}", thing, key, date)
                               + ((hour != null) ? "?hour=" + hour : null)
                               + ((responseType != null) ? "?responseType=" + responseType : null);
            return await _dweetIOClient.GETWithContentReturned(uri);
        }

        ///ALERTS
        public static async Task<bool> Alert(string who, string thing, string condition, string key)
        {
            if (string.IsNullOrEmpty(who)) { throw new ArgumentException("who can't be null or empty"); }
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(condition)) { throw new ArgumentException("condition can't be null or empty"); }
            if (string.IsNullOrEmpty(key)) { throw new ArgumentException("key can't be null or empty"); }

            string uri = string.Format("https://dweet.io/alert/{0}/when/{1}/{2}?key={3}", who, thing, condition, key);
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }

        public static async Task<string> GetAlertFor(string thing, string key)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(key)) { throw new ArgumentException("key can't be null or empty"); }

            string uri = string.Format("https://dweet.io/get/alert/for/{0}?key={1}", thing, key);
            return await _dweetIOClient.GETWithContentReturned(uri);
        }

        public static async Task<bool> RemoveAlertFor(string thing, string key)
        {
            if (string.IsNullOrEmpty(thing)) { throw new ArgumentException("thing can't be null or empty"); }
            if (string.IsNullOrEmpty(key)) { throw new ArgumentException("key can't be null or empty"); }

            string uri = string.Format("https://dweet.io/remove/alert/for/{0}?key={1}", thing, key);
            return await _dweetIOClient.GETWithDidSucceedReturned(uri);
        }
    }
}
