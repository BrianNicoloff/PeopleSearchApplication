let fs = require('fs');
const sourcePath = '../PeopleSearchApplication/Scripts/App/index.html';
const destPath = '../PeopleSearchApplication/Views/Home/Index.cshtml';
    
let replaceScriptPathInIndex = () => {
    let fileContent = fs.readFileSync(sourcePath, 'utf8');
    fileContent = fileContent.replace(/src="/g, 'src="~/Scripts/App/');
    fs.writeFileSync(destPath, fileContent, 'utf8');
};

module.exports = replaceScriptPathInIndex();