const electron = require('electron')
const path = require('path')
const url = require('url')
const LocalFetch = require('./local-fetch')

const baseNetAppPath = path.join(__dirname, '\\LocalFetch\\Hello.Console\\bin\\Debug\\PublishOutput');

process.env.EDGE_USE_CORECLR = 1;
process.env.EDGE_APP_ROOT = baseNetAppPath;

var edge = require('electron-edge-js');
// Module to control application life.
const app = electron.app
    // Module to create native browser window.
const BrowserWindow = electron.BrowserWindow



// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mainWindow

let localFetch = new LocalFetch();
app.localFetch = localFetch.localFetch;

function createWindow() {
    // Create the browser window.
    mainWindow = new BrowserWindow({ width: 800, height: 600 })

    // and load the index.html of the app.
    mainWindow.loadURL(url.format({
        pathname: path.join(__dirname, 'index.html'),
        protocol: 'file:',
        slashes: true
    }))

    var localFetch = edge.func({
        assemblyFile: path.join(baseNetAppPath, 'Fetch.Core.dll'),
        typeName: 'Fetch.Core.Local',
        methodName: 'Fetch'
    });

    app.localFetch('local://v1/programs/is-installed', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'X-Symc-Fetch-App-Version': '1.0'
        },
        body: {
            displayName: 'Norton Internet Security'
        }
    }).then((data) => {
        console.log('local://v1/programs/is-installed', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'X-Symc-Fetch-App-Version': '1.0'
            },
            body: {
                displayName: 'Norton Internet Security'
            }
        }, data);
    }).catch((e) => {
        console.log('local://v1/programs/is-installed', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'X-Symc-Fetch-App-Version': '1.0'
            },
            body: {
                displayName: 'Norton Internet Security'
            }
        }, e);
    });


    app.localFetch('local://v1/test/hello-there', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'X-Symc-Fetch-App-Version': '1.0'
        },
        body: {
            name: 'I am Vader'
        }
    }).then((data) => {
        console.log('local://v1/test/hello-there', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'X-Symc-Fetch-App-Version': '1.0'
            },
            body: {
                name: 'I am Vader'
            }
        }, data);
    }).catch((e) => {
        console.log('local://v1/test/hello-there', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'X-Symc-Fetch-App-Version': '1.0'
            },
            body: {
                name: 'I am Vader'
            }
        }, e);
    });



    app.localFetch('local://v1/test/app-domain', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((data) => {
        console.log('local://v1/test/app-domain', {
            method: 'GET',
            headers: {},
            body: {}
        }, data);
    }).catch((e) => {
        console.log('local://v1/test/app-domain', {
            method: 'GET',
            headers: {},
            body: {}
        }, e);
    });




    app.localFetch('local://v1/test/current-time', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((data) => {
        console.log('local://v1/test/current-time', {
            method: 'GET',
            headers: {},
            body: {}
        }, data);
    }).catch((e) => {
        console.log('local://v1/test/current-time', {
            method: 'GET',
            headers: {},
            body: {}
        }, e);
    });


    app.localFetch('local://v1/test/return-false', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((data) => {
        console.log('local://v1/test/return-false', {
            method: 'GET',
            headers: {},
            body: {}
        }, data);
    }).catch((e) => {
        console.log('local://v1/test/return-false', {
            method: 'GET',
            headers: {},
            body: {}
        }, e);
    });

    app.localFetch('local://v1/test/return-true', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((data) => {
        console.log('local://v1/test/return-true', {
            method: 'GET',
            headers: {},
            body: {}
        }, data);
    }).catch((e) => {
        console.log('local://v1/test/return-true', {
            method: 'GET',
            headers: {},
            body: {}
        }, e);
    });

    app.localFetch('local://v1/test/does-not-exit', {
        method: 'GET',
        headers: {},
        body: {}
    }).then((data) => {
        console.log('local://v1/test/does-not-exit', {
            method: 'GET',
            headers: {},
            body: {}
        }, data);
    }).catch((e) => {
        console.log('local://v1/test/does-not-exit', {
            method: 'GET',
            headers: {},
            body: {}
        }, e);
    });

    // Open the DevTools.
    // mainWindow.webContents.openDevTools()

    // Emitted when the window is closed.
    mainWindow.on('closed', function() {
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        mainWindow = null
    })
}

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
// Some APIs can only be used after this event occurs.
app.on('ready', createWindow)

// Quit when all windows are closed.
app.on('window-all-closed', function() {
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if (process.platform !== 'darwin') {
        app.quit()
    }
})

app.on('activate', function() {
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (mainWindow === null) {
        createWindow()
    }
})

// In this file you can include the rest of your app's specific main process
// code. You can also put them in separate files and require them here.