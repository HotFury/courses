// JavaScript source code
var wordsArray = ["бесснежный", "снег", "снеговик", "подснежник", "снеговой", "снежный", "снегопад"];
function FindLemm(words)
{
    // find shortest word and put it to first element 
    // (needs for correct regular expression working)
    var minLength = words[0].length; 
    var num = 0;                              
    for (var i = 1; i < words.length; i++)
    {
        if (words[i].length < minLength)
        {
            minLength = words[i].length;
            num = i;
        }
    }
    var temp = words[0];
    words[0] = words[num];
    words[num] = temp;          // now shortest word first
    var allWords = "";
    var regExp = "([a-zа-я]+)"; // regular expression beginning for lemma search (first word must be prefixless)
    for (var i = 0; i < words.length; i++)
    {
        allWords += words[i].toLowerCase(); // pushing all words to string
        if (i != 0)                         // first word must have NO reference to group
        {
            regExp += "[a-zа-я]*\\1";       //updating regular expression (adding references to lemma)
        }
    }
    var reg = new RegExp(regExp);
    var result = reg.exec(allWords)[1]; // find lemma by regular expression
    //lemma can't be one letter
    if (result.length == 1)
        result = "";
    console.log(result);
    return result;
}

function GetLink()
{
    var link = document.getElementById("url").value;
    return link;
}
function ShowDomainName()
{
    var link = GetLink();
    alert("domain name: " + GetDomainName(link));
}
function ShowPageName()
{
    var link = GetLink();
    alert("current page(catalog): " + GetCurPage(link));
}

function GetDomainName(url_link) 
{
    var regExp = /(http:\/\/|https:\/\/)[a-z0-9-_]+[.][a-z]+[.a-z]*/;
    var domainName = regExp.exec(url_link);
    if (domainName != null)
    {
        domainName = domainName[0].replace(domainName[1], ""); // removing "http://" or "https://" from beginning
    }
    return domainName;
}
function GetCurPage(url_link)
{
    var regExpPage = /.*(\/[a-z0-9-_]+[\.a-z]*)/;
    var curPage = regExpPage.exec(url_link);
    if (curPage != null)
    {
        curPage = curPage[1];
    }
    return curPage;
}

window.onload = function ()
{
    var res = FindLemm(wordsArray);
    var display = document.getElementById("lemma");
    display.appendChild(document.createTextNode(res));
    var domainButton = document.getElementById("domName");
    domainButton.onclick = ShowDomainName;
    var pageButton = document.getElementById("curPage");
    pageButton.onclick = ShowPageName;
}