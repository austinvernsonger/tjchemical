function showName(){
var tabView = new YAHOO.widget.TabView();
tabView.addTab( new YAHOO.widget.Tab({
label: '全部',
dataSrc: '../NoticeGet.aspx',
cacheData: true,
active: true}));
tabView.addTab( new YAHOO.widget.Tab({
label: '党支部',
dataSrc: '../NoticeGet.aspx?Label=%e5%85%9a%e6%94%af%e9%83%a8',
cacheData: true,
active: false}));
tabView.addTab( new YAHOO.widget.Tab({
label: '竞赛',
dataSrc: '../NoticeGet.aspx?Label=%e7%ab%9e%e8%b5%9b',
cacheData: true,
active: false}));
tabView.addTab( new YAHOO.widget.Tab({
label: '教务处',
dataSrc: '../NoticeGet.aspx?Label=%e6%95%99%e5%8a%a1%e5%a4%84',
cacheData: true,
active: false}));
tabView.addTab( new YAHOO.widget.Tab({
label: '研究生',
dataSrc: '../NoticeGet.aspx?Label=%e7%a0%94%e7%a9%b6%e7%94%9f',
cacheData: true,
active: false}));
tabView.addTab( new YAHOO.widget.Tab({
label: '本科生',
dataSrc: '../NoticeGet.aspx?Label=%e6%9c%ac%e7%a7%91%e7%94%9f',
cacheData: true,
active: false}));
tabView.appendTo('container');}
