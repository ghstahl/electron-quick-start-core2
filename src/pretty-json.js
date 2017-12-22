module.exports = class PrettyPrint {
    // ..and an (optional) custom class constructor. If one is
    // not supplied, a default constructor is used instead:
    // constructor() { }
    constructor() {
        let self = this;
        
        self.prettyPrint = (obj) => {
            let myPromise = new Promise((resolve, reject) => {
                var jsonLine = /^( *)("[\w]+": )?("[^"]*"|[\w.+-]*)?([,[{])?$/gm;
                    return JSON.stringify(obj, null, 3)
                        .replace(/&/g, "&amp;")
                        .replace(/\\"/g, "&quot;")
                        .replace(/</g, "&lt;")
                        .replace(/>/g, "&gt;")
                        .replace(jsonLine,self.replacer);
            });
            return myPromise;
        }
        self.replacer = (match, pIndent, pKey, pVal, pEnd) => {
            var key = "<span class=json-key>";
            var val = "<span class=json-value>";
            var str = "<span class=json-string>";
            var r = pIndent || "";
            if (pKey) r = r + key + pKey.replace(/[": ]/g, "") + "</span>: ";
            if (pVal) r = r + (pVal[0] == '"' ? str : val) + pVal + "</span>";
            return r + (pEnd || "");
        } 
    }
}
