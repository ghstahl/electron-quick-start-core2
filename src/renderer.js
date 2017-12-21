// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// All of the Node.js APIs are available in this process.

const LocalFetch = require('./local-fetch')
let localFetch = (new LocalFetch()).localFetch;


window.onload = function() {

    localFetch('local://v1/test/hello-there', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'X-Symc-Fetch-App-Version': '1.0'
        },
        body: {
            name: 'I am Vader'
        }
    }).then((result) => {
        document.getElementById("HelloThere").innerHTML = result.value;
        console.log(result);
    }).catch((e) => {
        console.log(e);
    });
    localFetch('local://v1/test/app-domain', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((result) => {
        document.getElementById("AppDomain").innerHTML = result.value;
        console.log(result);
    }).catch((e) => {
        console.log(e);
    });

    localFetch('local://v1/test/current-time', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((result) => {
        document.getElementById("CurrentTime").innerHTML = result.value;
        console.log(result);
    }).catch((e) => {
        console.log(e);
    });



};