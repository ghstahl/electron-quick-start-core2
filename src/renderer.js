// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// All of the Node.js APIs are available in this process.

const path = require('path');
const baseNetAppPath = path.join(__dirname, '\\LocalFetch\\Hello.Console\\bin\\Debug\\PublishOutput');

process.env.EDGE_USE_CORECLR = 1;
process.env.EDGE_APP_ROOT = baseNetAppPath;

var edge = require('electron-edge-js');

var localFetch = edge.func({
    assemblyFile: path.join(baseNetAppPath, 'Fetch.Core.dll'),
    typeName: 'Fetch.Core.Local',
    methodName: 'Fetch'
  });

  localFetch({
    url: 'local://v1/test/hello-there',
    method: 'GET',
    headers: {
        'Content-Type': 'application/json',
        'X-Symc-Fetch-App-Version': '1.0'
      },
      body: {
          name: 'I am Vader'
      }
  }, function(error, result) {
      if (error) throw error;
      console.log(result);
  });
