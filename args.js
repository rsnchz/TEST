console.log(process.argv);

const  args = process.argv.slice(2);

for ( let arg of args){

    console.log(`Hi..., ${arg}`);
}

const fs = require('fs');
//const folderName = process.argv[2];

fs.mkdirSync('project');
fs.writeFileSync(`project/index.html`);
