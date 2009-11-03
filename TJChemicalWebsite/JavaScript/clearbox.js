/*                                                                                                                                                                              
	ClearBox JS by pyro
	
	script home:		http://www.clearbox.hu
	developer's e-mail:	georgekrupa(at)gmail(dot)com
	developer's msn:	pyro(at)radiomax(dot)hu
	support forum:		http://www.sg.hu/listazas.php3?id=1172325655

	LICENSE:

	Using of the script is free for any non-commercial webpages without any commercial activities,
	without advertising or selling anything. If you want to use it on a commercial page, please contact the developer.
	The source code of the script (except of user variable settings) can be changed only with the developer's written permission.

*/


//
// 	User variable settings:
//

var

	CB_HideColor='#000', 
	CB_WinPadd=10,
	CB_RoundPix=12,
	CB_Animation='double',
	CB_ImgBorder=0,
	CB_ImgBorderColor='#000',
	CB_Padd=4,
	CB_ShowImgURL='on',
	CB_ImgNum='on',
	CB_ImgNumBracket='()',
	CB_SlShowTime=3,
	CB_TextH=30,
	CB_Font='Verdana',
	CB_FontSize=12,
	CB_FontColor='#777',
	CB_FontWeight='normal',
	CB_Font2='arial',
	CB_FontSize2=12,
	CB_FontColor2='#999',
	CB_FontWeight2='normal',
	CB_PicDir='Resources/ClearBox',
	CB_BodyMarginLeft=0,
	CB_BodyMarginRight=0,
	CB_BodyMarginTop=0,
	CB_BodyMarginBottom=0,
	CB_Preload='on',
	CB_TextNav='off',
	CB_NavTextPrv='Previous',
	CB_NavTextNxt='Next',
	CB_NavTextFull='Full',
	CB_NavTextDL='DL',
	CB_NavTextClose='�ر�',
	CB_NavTextStart='SlideShow Start',
	CB_NavTextStop='SlideShow Stop',
	CB_NavTextImgPrv='on',
	CB_NavTextImgNxt='on',
	CB_NavTextImgFull='on',
	CB_NavTextImgDL='on',
	CB_PictureStart='start.png',
	CB_PicturePause='pause.png',
	CB_PictureClose='close.png',
	CB_PictureLoading='loading.gif',
	CB_PictureNext='next.png',
	CB_PicturePrev='prev.png',
	CB_HideOpacitySpeed=400,
	CB_ImgOpacitySpeed=450,
	CB_TextOpacitySpeed=350,
	CB_HideOpacity=.85,
	CB_AnimSpeed=600,
	CB_ImgTextFade='on',
	CB_FlashHide='off',
	CB_SelectsHide='on',
	CB_NoThumbnails='off', 
	CB_SimpleDesign='off',
	CB_ImgMinWidth=200,
	CB_ImgMinHeight=160,
	CB_CloseOnH='on',
	CB_ShowGalName='on',
	CB_AllowedToRun='on',
	CB_AllowExtFunct='off',
	CB_FullSize='on'

;

//
//	Do not change the following code!
//

eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('2 $6(){d(4.j==1)3 7$6(4[0]);5 b=[];$c(4).h(2(a){b.x(7$6(a))});3 b;2 7$6(a){d(s a==\'r\')a=p.n(a);3 a}};m.l.k=2(a){5 b=8;3 2(){3 b.e(a,4)}};i=2(a,b){o(9 q b)a[9]=b[9];3 a};d(!g.f)5 f=u t();5 v={w:2(){3 2(){8.y.e(8,4)}}};',35,35,'||function|return|arguments|var|CB|get|this|kifejezes||||if|apply|CBEE|window|each|Kiterjeszt|length|lancol|prototype|Function|getElementById|for|document|in|string|typeof|Object|new|Osztaly|letrehoz|push|azonnallefut'.split('|'),0,{}));eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('s i=t 1i();i.F=3(){};i.F.1z={1r:3(a){1.7=14({z:3(){},y:3(){},Y:i.1v.1p,n:1h,N:\'k\',S:18,E:C},a||{})},B:3(){s a=t A().T();4(a<1.m+1.7.n){4(1.8.f(\'d\')==\'1t\'&&1o==\'1n\'){1.9=1.j;1.g();6}4((1.8.f(\'d\')==\'u\'||1.8.f(\'d\')==\'1g\'||1.8.f(\'d\')==\'1e\')&&1b==\'1a\'){1.g();6}1.H=a-1.m;1.V()}r{D(1.7.y.w(1,1.8),10);1.g();1.9=1.j}1.O()},V:3(){1.9=1.P(1.Q,1.j)},P:3(a,b){s c=b-a;6 1.7.Y(1.H,a,c,1.7.n)},g:3(){13(1.l);1.l=12;6 1},x:3(a,b){4(!1.7.S)1.g();4(1.l)6;D(1.7.z.w(1,1.8),10);1.Q=a;1.j=b;1.m=t A().T();1.l=11(1.B.w(1),Z.1y(1x/1.7.E));6 1},1w:3(a,b){6 1.x(a,b)},X:3(a){1.9=a;1.O();6 1},1u:3(){6 1.X(0)},1s:3(e,p,v){4(1.8.f(\'d\')==\'u\'&&p==\'R\'){I=M(1l-(1k+1.9+1j+(2*(L+o+K)))/2);J.5.1f=(I-(1m/2))+\'k\';1d.5.R=1.9+(2*o)+\'k\'}4(1.8.f(\'d\')==\'u\'&&p==\'1c\'){U=M(1q-(1.9+(2*(L+o+K)))/2);J.5.19=U+\'k\'}4(p==\'q\'){4(v==0&&e.5.h!="W")e.5.h="W";r 4(e.5.h!="G")e.5.h="G";4(17.16)e.5.15="1A(q="+v*C+")";e.5.q=v}r e.5[p]=v+1.7.N}};',62,99,'|this||function|if|style|return|params|CBe|most||||id||getAttribute|clearTimer|visibility|CB_effektek|hova|px|timer|time|idotartam|CB_ImgBorder||opacity|else|var|new|CB_Image||lancol|_start|halefutott|haelindul|Date|effekt_lepes|100|setTimeout|fps|alap|visible|cTime|CB_MarginT|CB_Win|CB_Padd|CB_RoundPix|parseInt|egyseg|noveles|compute|honnan|height|varakozas|getTime|CB_MarginL|setNow|hidden|set|effekt|Math||setInterval|null|clearInterval|Kiterjeszt|filter|ActiveXObject|window|true|marginLeft|on|CB_Break|width|CB_ImgCont|CB_iFrame|marginTop|CB_TL|500|Object|CB_TextH|CB_ieRPBug|DocScrY|FF_ScrollbarBug|off|CB_SSTimer|evlassitva|DocScrX|parameterek|setStyle|CB_SlideShowBar|elrejt|Effektek|sajat|1000|round|prototype|alpha'.split('|'),0,{}));eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('7.z=r.j();7.z.i=f(w 7.n(),{m:5(a,b){3.4=$u(a);3.g(b);3.4.E.D=\'B\'},l:5(){k(3.4.A>0)6 3.8(3.4.A,0);h 6 3.8(0,3.4.x)},q:5(){6 3.e(3.4.x)},s:5(){3.v(3.4,\'M\',3.9)}});7.F=r.j();7.F.i=f(w 7.n(),{m:5(a,b){3.4=$u(a);3.g(b);3.4.E.D=\'B\';3.p=3.4.o},l:5(){k(3.4.o>0)6 3.8(3.4.o,0);h 6 3.8(0,3.p)},q:5(){6 3.e(3.p)},s:5(){3.v(3.4,\'L\',3.9)}});7.C=r.j();7.C.i=f(w 7.n(),{m:5(a,b){3.4=$u(a);3.g(b);3.9=1},l:5(){k(3.9>0)6 3.8(1,0);h 6 3.8(0,1)},q:5(){6 3.e(1)},s:5(){3.v(3.4,\'K\',3.9)}});7.J={I:5(t,b,c,d){6 c*t/d+b},H:5(t,b,c,d){6-c/2*(y.G(y.N*t/d)-1)+b}};',50,50,'|||this|CBe|function|return|CB_effektek|sajat|most|||||set|Kiterjeszt|parameterek|else|prototype|letrehoz|if|toggle|azonnallefut|alap|offsetWidth|iniWidth|show|Osztaly|noveles||CB|setStyle|new|scrollHeight|Math|magassag|offsetHeight|hidden|Atlatszosag|overflow|style|szelesseg|cos|evlassitva|egyenletes|Effektek|opacity|width|height|PI'.split('|'),0,{}));eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('E 76=\'2.61\',2Z=1;1X=-50,1O=5,3v=\'F\';l(1x==\'F\'){1x=\'3w\';1Y=1}p 5l(a){E b;l(!a)E a=Q.4a;E b=(a.5m)?a.5m:a.77;E c=78.79(b);l(2b==\'o\'){l(x>1&&(c=="%"||b==37||b==52)){l(1f==\'o\'){1y()}1n(x-1);v M}l(x<u.B-1&&(c=="\'"||b==39||b==54)){l(1f==\'o\'){1y()}1n(x+1);v M}l((c==" "||b==32)&&2G==0){l(u.B<3){v M}l(2c==\'2H\'){4b();v M}t{4c();v M}}l(c==""||b==27){3x();v M}l(b==13){v M}}t{l(2G==1&&(c==" "||b==32||b==13)){v M}}}p 4b(){1P.k.y=\'K\';1Q.k.y=\'16\';2c=\'4d\';1K.k.y=\'16\';4e()}p 4c(){1Q.k.y=\'K\';1P.k.y=\'16\';4f()}31=O(31);l(31<0){31=0}33=O(33);l(33<0){33=0}34=O(34);l(34<0){34=0}35=O(35);l(35<0){35=0}l(2I<0||2I>1){2I=0.75}2d=O(2d);l(2d<1||2d>4g){2d=7a}2e=O(2e);l(2e<1||2e>4g){2e=5n}2J=O(2J);l(2J<1||2J>4g){2J=7b}1C=O(1C);l(1C<0){1C=1}l(1x!=\'F\'&&1x!=\'5o\'&&1x!=\'3w\'&&1x!=\'3y\'){1x=\'3w\'}I=O(I);l(I<0){I=1}1o=O(1o);l(1o<0){1o=2}l(38!=\'o\'&&38!=\'F\'){38=\'F\'}1O=O(1O);l(1O<0){1O=0}V=O(V);l(V<0){V=12}1g=O(1g);l(1g<25){1g=25}l(3a==\'o\'){1g=0;1O=0}2K=O(2K);l(2K<6){2K=12}3b=O(3b);l(3b<6){3b=11}l(3c!=\'o\'&&3c!=\'F\'){3c=\'o\'}2L=O(2L);l(2L<1){2L=5}2L*=5p;l(3v!=\'o\'&&3v!=\'F\'){3v=\'F\'}l(3d!=\'o\'&&3d!=\'F\'){3d=\'o\'}l(2f!=\'o\'&&2f!=\'F\'){2f=\'o\'}l(2M!=\'o\'&&2M!=\'F\'){2M=\'F\'}l(2N!=\'o\'&&2N!=\'F\'){2N=\'o\'}l(3z!=\'o\'&&3z!=\'F\'){3z=\'F\'}l(3a!=\'o\'&&3a!=\'F\'){3a=\'F\'}l(3A!=\'o\'&&3A!=\'F\'){3A=\'o\'}l(3e!=\'o\'&&3e!=\'F\'){3e=\'o\'}l(2q!=\'o\'&&2q!=\'F\'){2q=\'o\'}l(3f!=\'o\'&&3f!=\'F\'){3f=\'F\'}l(3B!=\'o\'&&3B!=\'F\'){3B=\'o\'}l(3C!=\'o\'&&3C!=\'F\'){3C=\'o\'}l(3D!=\'o\'&&3D!=\'F\'){3D=\'o\'}l(3E!=\'o\'&&3E!=\'F\'){3E=\'o\'}l(3F!=\'o\'&&3F!=\'F\'){3F=\'o\'}1Y=O(1Y);l(1Y<1){1Y=5n}2r=O(2r);l(2r<50){2r=50}2s=O(2s);l(2s<50){2s=50}E 3G,2O=3H,5q=1X,3I,7c,3g,3J=\'\',7d=0,2g,7e,2G,2t,2P,4h=0,4i=\'\',2b,3K=31+33,3L=34+35,3M,N,3N=0,1f,2c=\'2H\',1Z,4j,4k,5r,z,H,3O,2u,1L,D,1R,1S,2h,2i,x,u,3P,2Q,3Q,3h,3i,2v,2w;P+=\'/\';E 4l=m.7f?3H:M;l(!4l)m.7g(7h.7i);l(3B==\'o\'){E 1D=4m;4m=\'<1s 1t="3R" C="\'+P+\'5s.19" 1h="\'+1D+\'" 1E="\'+1D+\'" />\'}l(3C==\'o\'){E 1D=4n;4n=\'<1s 1t="3R" C="\'+P+\'5t.19" 1h="\'+1D+\'" 1E="\'+1D+\'" />\'}l(3D==\'o\'){E 1D=3S;3S=\'<1s 1t="3R" C="\'+P+\'5u.19" 1h="\'+1D+\'" 1E="\'+1D+\'" />\'}l(3E==\'o\'){E 1D=4o;4o=\'<1s 1t="3R" C="\'+P+\'5v.19" 1h="\'+1D+\'" 1E="\'+1D+\'" />\'}p 5w(a,b){l(3j Q.2R!=\'3k\'){Q.2R(a,b,M)}t l(3j m.2R!=\'3k\'){m.2R(a,b,M)}t l(3j Q.5x!=\'3k\'){Q.5x("o"+a,b)}}5w(\'7j\',5y);p 5y(){m.7k=5l;m.X.k.7l="7m";E a=\'<J 1t="7n" k="G: \'+V+\'q; R: \'+V+\'q;"></J>\';l(14.15.Y("2x")!=-1){3J=\'<1s A="4p" 1h="" C="\'+P+\'2y.19" />\'}t{3J=\'<J A="4p"></J>\'}l(!m.r(\'4q\')&&2Z!=0){E b=m.2j("X").7o(0);E c=m.4r("J");c.5z(\'A\',\'5A\');b.1u(c);E d=m.4r("J");d.5z(\'A\',\'4q\');b.1u(d)}m.r(\'4q\').T=\'<J A="5B"></J><J A="5C"></J><5D 7p="0" 7q="0" A="5E"><2S A="3h"><1a A="4s">\'+a+\'</1a><1a A="4t"></1a><1a A="4u">\'+a+\'</1a></2S><2S A="7r"><1a A="2v"></1a><1a A="5r" 7s="3l" 7t="2k"><J A="5F"><J A="5G"><1s A="4v" 1h="\'+5H+\'" 1E="\'+5H+\'" C="\'+P+5I+\'" /><J A="5J"></J>\'+3J+\'<J A="4w"><J A="5K"></J></J><1s A="5L" 1h="7u" C="\'+P+5M+\'" /><1s A="5N" 1h="" C="\'+P+\'2y.19" /><J A="3T"><1s A="4x" 1h="" C="\'+P+5O+\'" /><1s A="4y" 1h="" C="\'+P+5P+\'" /><J A="5Q"></J><1s A="4z" 1h="\'+5R+\'" 1E="\'+5R+\'" C="\'+P+5S+\'" /><1s A="4A" 1h="\'+5T+\'" 1E="\'+5T+\'" C="\'+P+5U+\'" /><a A="5V"></a><a A="5W"></a></J></J><J A="5X"><J A="5Y"></J><J A="5Z"></J><J A="60"></J></J></J></1a><1a A="2w"></1a></2S><2S A="3i"><1a A="4B">\'+a+\'</1a><1a A="4C"></1a><1a A="4D">\'+a+\'</1a></2S></5D>\';l(14.15.Y("2x 6")!=-1&&V==0){4i=1}l(14.15.Y("2x")!=-1&&V<2){4h=6}m.r(\'5F\').k.7v=1o+\'q\';2T=m.r(\'4p\');1p=m.r(\'5Q\');1p.k.62=\'#7w\';1p.k.1i=0.75;1p.k.1d=\'2l(1i=75)\';2u=m.r(\'5E\');2z=m.r(\'4w\');3m=m.r(\'5K\');l(3z==\'o\'){2T.k.y=\'K\'}1b=m.r(\'5B\');1b.k.62=7x;1b.k.1i=0;1b.k.1d=\'2l(1i=0)\';4E=U 1F.2A(1b,{1G:2d,1T:p(){4F(\'3n\')}});4E.2U();4G=U 1F.2A(1b,{1G:2d,1T:p(){1n()}});4G.2U();4H=U 1F.2A(1b,{1G:2d,1T:p(){1b.k.G=\'1j\';1b.k.R=\'1j\';1Z.k.w=\'S\';2b=\'F\'}});4H.2U();D=m.r(\'5N\');1Z=m.r(\'5L\');2V=m.r(\'5G\');D.k.7y=I+\'q 7z \'+7A;2B=m.r(\'4v\');2B.1q=p(){3x()};1P=m.r(\'4A\');1Q=m.r(\'4z\');1P.1q=p(){4b();v M};1Q.1q=p(){4c();v M};1K=m.r(\'5C\');1K.k.1i=0.5;1K.k.1d=\'2l(1i=50)\';2m=m.r(\'4x\');2m.20=p(){2m.k.w=\'1c\'};2m.1q=p(){l(1f==\'o\'){1y()}1n(x-1);v M};2n=m.r(\'4y\');2n.20=p(){2n.k.w=\'1c\'};2n.1q=p(){l(1f==\'o\'){1y()}1n(x+1);v M};1R=m.r(\'5V\');1R.k.1U=\'63(\'+P+\'2y.19)\';1R.20=p(){2m.k.w=\'1c\'};1R.64=p(){2m.k.w=\'S\'};1S=m.r(\'5W\');1S.k.1U=\'63(\'+P+\'2y.19)\';1S.20=p(){2n.k.w=\'1c\'};1S.64=p(){2n.k.w=\'S\'};1v=m.r(\'60\');1L=m.r(\'5X\');1L.k.R=(1g-1O)+\'q\';1v.k.3l=\'-\'+(1g-1O)+\'q\';1v.k.R=(1g-1O+3)+\'q\';1L.k.65=1O+\'q\';l(3a==\'o\'){1L.k.y=\'K\';1g=0}t{1L.k.y=\'16\'}W=m.r(\'5Y\');W.k.4I=66;W.k.4J=67;W.k.68=7B;W.k.4K=2K+\'q\';1k=m.r(\'5A\');1k.k.4I=66;1k.k.4J=67;1k.k.4K=2K+\'q\';1l=m.r(\'5Z\');1l.k.4I=7C;1l.k.4J=7D;1l.k.68=7E;1l.k.4K=3b+\'q\';3h=m.r(\'3h\').k;3h.R=V+\'q\';3i=m.r(\'3i\').k;3i.R=V+\'q\';2v=m.r(\'2v\').k;2v.G=V+4i+\'q\';2w=m.r(\'2w\').k;2w.G=V+\'q\';4L=m.r(\'5J\');l(2f==\'o\'){4M=U 1F.2A(1v,{1G:2J,1T:p(){3o()}});4N=U 1F.2A(D,{1G:2e,1T:p(){3U()}});4N.2U();69=U 1F.2A(D,{1G:2e});69.2U()}4O=m.r(\'3T\').k;2T.20=p(){6a();v};1p.20=p(){3V();v};1L.20=p(){3V();v};1b.20=p(){3V();v};l(14.15.Y("3p")!=-1){3K=0;3L=0}l(14.15.Y("3W")!=-1){3L=0}m.r(\'4w\').7F=6b;E e=0;E f=0;E g=U 2C("2y.19","6c.19","6d.1e","6e.1e","6f.1e","6g.1e","6h.1e","6i.1e","6j.1e","6k.1e","7G.19",5U,5S,5I,5M,5P,5O,"5s.19","5t.19","5u.19","5v.19");E h=U 2C();N=m.2j(\'a\');1z(i=0;i<N.B;i++){L=N[i].1A;7H=N[i].17(\'2o\');l(L.6l(\'1w\')!=21&&2Z!=0){l(L==\'1w\'){N[i].1q=p(){l(2q==\'o\'){4P(Z.1A+\'+\\\\+\'+Z.17(\'2o\')+\'+\\\\+\'+Z.17(\'1E\'));v M}}}t{l(L.1H(0,8)==\'1w\'&&L.3X(8)==\'[\'&&L.3X(L.B-1)==\']\'){l(N[i].1A.1H(9,N[i].1A.B-1).22(\',,\')[0]!=\'1w\'){N[i].1q=p(){l(2q==\'o\'){4P(Z.1A.1H(9,Z.1A.B-1)+\'+\\\\+\'+Z.17(\'2o\')+\'+\\\\+\'+Z.17(\'1E\'));v M}}}t{6m(\'6n 6o#1:\\n\\7I 7J 7K 7L 7M "1w[1w]"!\\n(6p: m, \'+i+\'. <a>.)\')}l(N[i].17(\'2D\')!=21&&N[i].17(\'2D\')!=\'21\'){g.23(N[i].17(\'2D\'));E j=m.4r(\'1s\');j.C=N[i].17(\'2D\');j.1h=\'\';j.7N=\'7O\';N[i].1u(j)}}t l(L.1H(0,8)==\'1w\'&&L.3X(8)==\'(\'&&L.3X(L.B-1)==\')\'){l(L.1H(9,L.B-1).22(\',,\')[2]==\'7P\'){N[i].1q=p(){l(2q==\'o\'){4Q(Z.1A.1H(9,Z.1A.B-1)+\'+\\\\+\'+Z.17(\'2o\')+\'+\\\\+\'+Z.17(\'1E\'));v M}}}t{N[i].20=p(){l(2q==\'o\'){4Q(Z.1A.1H(9,Z.1A.B-1)+\'+\\\\+\'+Z.17(\'2o\')+\'+\\\\+\'+Z.17(\'1E\'));v M}}}}t{6m(\'6n 6o#2:\\n\\n: 7Q 7R 7S: "\'+N[i].1A+\'"!\\n(6p: m, \'+i+\'. <a>.)\')}}}}1z(i=0;i<g.B;i++){h[i]=U 2W();h[i].C=P+g[i]}2h=z=2r;2i=H=2s-1g;l(14.15.Y("2x")!=-1&&14.15.Y("7T")!=-1&&14.15.Y("2x 7")==-1&&14.15.Y("2x 8")==-1){6q()}}p 4P(a){l(2Z==0){v M}2O=M;3G=\'F\';1m=a.22(\'+\\\\+\');L=1m[0].22(\',,\');l(L[1]>0){4R=O(L[1])*5p}t{4R=2L}l(L[2]==\'2H\'){2c=\'4d\'}l(u&&L[0]==u[0][0]&&u[0][0]!=\'1w\'){}t{u=U 2C;u.23(U 2C(L[0],L[1],L[2]));l(1m[0]==\'1w\'){u.23(U 2C(1m[1],1m[2]))}t{1z(i=0;i<N.B;i++){l(N[i].1A.1H(9,N[i].1A.B-1).22(\',,\')[0]==u[0][0]){3g=P+\'6c.19\';l(N[i].17(\'2D\')==21||N[i].17(\'2D\')==\'21\'){1z(j=0;j<N[i].4S.B;j++){l(N[i].4S[j].C!=3k){3g=N[i].4S[j].C}}}t{3g=N[i].17(\'2D\')}u.23(U 2C(N[i].17(\'2o\'),N[i].17(\'1E\'),3g))}}}}x=0;7U(u[x][0]!=1m[1]){x++}4T();l(2N==\'o\'){4U()}l(2M==\'o\'){4V()}4W()}p 4T(){6r();6s();6t();l(1r>1V){1V=1r}l((14.15.Y("6u")!=-1||14.15.Y("3W")!=-1)&&1B!=1W){3M=Q.4X+Q.4Y-1V}t{3M=0}4Z();l(3K==0){l(1W>7V.G){1b.k.G=1W+\'q\'}t{1b.k.G=\'3q%\'}}t{1b.k.G=1W+3K+\'q\'}1b.k.R=1r+2E+\'q\';1b.k.w=\'1c\';v}p 4Q(a){l(2Z==0){v M}3G=\'F\';4L.T=\'<6v 7W="0" A="6w" C=""></6v>\';1M=m.r(\'6w\');1M.k.1i=0;1M.k.1d=\'2l(1i=0)\';l(2f==\'o\'){51=U 1F.2A(1M,{1G:2e,1T:p(){2B.k.y=\'16\';D.k.w=\'S\';4M.1I(1,0)}});51.2U()}2O=M;1L.k.G=\'1j\';1v.k.G=\'1j\';3Y();2b=\'F\';1m=a.22(\'+\\\\+\');1M.C=1m[1];4O.y=\'K\';L=1m[0].22(\',,\');4T();z=O(L[0]);H=O(L[1]);l(z>1B-(2*(V+I+1o+1C))){z=1B-(2*(V+I+1o+1C))}l(H>1r-(2*(V+I+1o+1C))-1g){H=1r-(2*(V+I+1o+1C))-1g}D.k.G=2h+\'q\';D.k.R=2i+\'q\';D.k.y=\'16\';D.k.w=\'S\';2u.k.w=\'1c\';2B.k.y=\'K\';1P.k.y=\'K\';1Q.k.y=\'K\';l(2N==\'o\'){4U()}l(2M==\'o\'){4V()}4W(\'3n\')}p 4W(a){l(a==\'3n\'){1Z.k.w=\'1c\';4E.1I(0,2I)}t{6x();4G.1I(0,2I)}1b.k.R=1V+3L+\'q\'}p 6x(){53();D.k.G=2h+\'q\';D.k.R=2i+\'q\';D.k.y=\'16\';D.k.w=\'S\';2u.k.w=\'1c\'}p 53(){1P.k.y=\'K\';1Q.k.y=\'K\';2B.k.y=\'K\';1R.k.y=\'K\';1S.k.y=\'K\'}p 1n(a){2b=\'F\';55();53();2m.k.w=\'S\';2n.k.w=\'S\';1L.k.G=\'1j\';1v.k.G=\'1j\';2z.k.G=\'1j\';1p.k.G=\'1j\';1p.k.R=\'1j\';2T.k.w=\'S\';2z.k.y=\'K\';1p.k.w=\'S\';3Y();l(a){l(z>2t){D.k.G=z+\'q\'}l(H>2P){D.k.R=H+\'q\'}}l(a){x=O(a)}l(1x!=\'3y\'){D.k.w=\'S\';1Z.k.w=\'1c\'}W.T=\'\';1l.T=\'\';3P=0;2Q=U 2W();2Q.C=u[x][0];3Q=M;3o();56()}p 56(){l(3P==1){57();3Q=3H;58(3Z);6y();v}l(3Q==M&&2Q.7X){3P++}3Z=6z("56()",5);v}p 6y(){z=2Q.G;H=2Q.R;2t=z;2P=H;3O=z/H;l(z<2r){z=2r}l(H<2s){H=2s}6A();D.C=u[x][0];4F();v}p 4F(a){2G=1;l(1x==\'3w\'){59(a)}t l(1x==\'3y\'){l(!a){1Z.k.w=\'S\';D.k.w=\'1c\';D.k.1i=1;D.k.1d=\'2l(1i=3q)\'}59(a)}t l(1x==\'F\'){4Z();2V.k.R=H+(2*I)+\'q\';D.k.G=z+\'q\';D.k.R=H+\'q\'}t l(1x==\'5o\'){6B(a)}v}p 6B(a){40=U 1F.5a(D,{1G:1Y,1T:p(){6C(a)}});40.1I(2h,z)}p 6C(a){41=U 1F.6D(D,{1G:1Y,1T:p(){l(a==\'3n\'){5b()}t{5c()}}});41.1I(2i,H)}p 59(a){40=U 1F.5a(D,{1G:1Y,1T:p(){l(a==\'3n\'){5b()}t{5c()}}});40.1I(2h,z);41=U 1F.6D(D,{1G:1Y});41.1I(2i,H)}p 5b(){6E()}p 6E(){l(3f==\'o\'){6F()}u=\'\';5d();D.k.w=\'1c\';D.k.1i=1;D.k.1d=\'2l(1i=3q)\';1Z.k.w=\'S\';1M.k.3l=I+\'q\';1M.k.2k=I+\'q\';1M.k.G=z+\'q\';1M.k.R=H+\'q\';W.k.6G=\'7Y\';l(1m[2]&&1m[2]!=\'21\'&&1m[2]!=21){1k.T=\'\';1k.1u(m.1N(1m[2]));l(1k.3r>z+(2*I)){5e(1m[2])}t{W.1u(m.1N(1m[2]))}}t{l(38==\'o\'){W.T=1m[1]}}2b=\'o\';2G=0;l(2f==\'o\'){51.1I(0,1)}t{1v.k.w=\'S\';1M.k.1i=1;1M.k.1d=\'2l(1i=3q)\';2B.k.y=\'16\';3o()}v}p 3o(){l(3A==\'o\'){1b.1q=p(){3x();v M}}}p 57(){1b.1q=\'\'}p 5c(){l(z>2t){2V.k.G=z+(2*I)+\'q\';D.k.G=2t+\'q\'}l(H>2P){2V.k.R=H+(2*I)+\'q\';D.k.R=2P+\'q\'}l(1x!=\'3y\'){W.T=\'\';1l.T=\'\';1Z.k.w=\'S\';D.C=u[x][0];l(2f==\'o\'){6H()}t{D.k.w=\'1c\';3U()}}t{3U()}}p 3U(){l(3f==\'o\'){6F()}W.k.6G=\'2k\';5d();l(u.B<3){1P.k.y=\'K\';1Q.k.y=\'K\'}t{l(2c==\'2H\'){1P.k.y=\'16\';1Q.k.y=\'K\'}t{1Q.k.y=\'16\';1P.k.y=\'K\'}}4O.y=\'16\';2B.k.y=\'16\';1R.k.R=H+\'q\';1S.k.R=H+\'q\';l(u[x][1]&&u[x][1]!=\'21\'&&u[x][1]!=21){1k.T=\'\';1k.1u(m.1N(u[x][1]));l(1k.3r>z+(2*I)){5e(u[x][1])}t{W.1u(m.1N(u[x][1]))}}t{l(38==\'o\'){W.1u(m.1N((u[x][0].22(\'/\'))[(u[x][0].22(\'/\').B)-1]))}}l(3e==\'o\'&&L[0]!="1w"){1l.1u(m.1N(L[0]))}l(3c==\'o\'&&u.B>2){1l.1u(m.1N(\' \'+6I.1H(0,1)+x+\'/\'+(u.B-1)+6I.1H(1,2)+\' \'))}l(3F==\'o\'){l((3e==\'o\'||3c==\'o\')&&L[0]!="1w"){1l.T+=\'<2p 1t="42"> | </2p>\'}E a=4o;l(2t>z||2P>H){a=3S}l(u[x][0].1H(u[x][0].B-4,u[x][0].B)==\'7Z\'){a=3S;1l.T+=\'<a 1t="2F" 6J="6K" 2o="\'+u[x][0].1H(0,u[x][0].B-4)+\'">\'+a+\'</a>\'}t{1l.T+=\'<a 1t="2F" 6J="6K" 2o="\'+u[x][0]+\'">\'+a+\'</a>\'}}l(2F==\'o\'&&L[0]!="1w"){1l.T+=\'<2p 1t="42"> | </2p>\'}3T();l(u.B>0){l(z>2t){2V.k.G=\'\'}2h=z;2i=H}l(u.B>2){l(2c==\'4d\'){1Q.k.y=\'16\';1K.k.y=\'16\';4e()}t{1P.k.y=\'16\'}}t{2c=\'2H\'}2b=\'o\';2G=0;1p.k.G=z+(2*I)+\'q\';1p.k.R=H+(2*I)+\'q\';6L();l(2f==\'o\'){4M.1I(1,0)}t{1v.k.w=\'S\';3o()}v}p 5e(a){1k.T=\'\';1k.1u(m.1N(a));1k.T+=\' | \';1k.1u(m.1N(a));1k.T+=\' | \';W.T=\'\';W.1u(m.1N(a));W.T+=\'<2p 1t="42"> | </2p>\';W.1u(m.1N(a));W.T+=\'<2p 1t="42"> | </2p>\';5f()}p 5f(){l(1X<0){1X++}t{l(1X<1k.3r/2){W.k.2k=-1X+\'q\';1X++}t{W.k.2k=\'1j\';1X=0}}3I=6z("5f()",30)}p 6L(){l(L[0]!="1w"){2T.k.w=\'1c\';2z.k.G=z+(2*I)+\'q\';2z.k.3l=H-70+\'q\';E a=\'\';E b=10;E c=0;E d=0;2g=0;43=U 2W();44=U 2W();1z(i=1;i<u.B;i++){43.C=u[i][2];c=45.46(43.G/43.R*50);l(c>0){}t{c=50}2g+=c}2g+=(u.B-2)*b;1z(i=1;i<u.B;i++){44.C=u[i][2];a+=\'<a 1q="l(1f==\\\'o\\\'){1y();}1n(\'+i+\')"><1s k="2k: \'+d+\'q;" C="\'+u[i][2]+\'" R="50" 1t="80" 1h="" /></a>\';d+=45.46(44.G/44.R*50)+b}3m.k.G=2g+\'q\';3m.T=a;3m.k.5g=(z-2g)/2+\'q\'}v}p 5d(){1v.k.G=z+(2*I)+\'q\';1L.k.G=z+(2*I)+\'q\'}p 3Y(){1v.k.1i=1;1v.k.1d=\'2l(1i=3q)\';1v.k.y=\'16\';1v.k.w=\'1c\'}p 6H(){4N.1I(0,1)}p 6a(){1p.k.w=\'1c\';2z.k.y=\'16\';v}p 3V(){1p.k.w=\'S\';2z.k.y=\'K\';v}p 6b(e){l(2g>z){l(4l){3s=4a.81}t{3s=e.82}l(3s<0){3s=0}3m.k.5g=((1B-z)/2-3s)/(z/(2g-z-(2*I)))+\'q\'}}p 55(){l(3I){58(3I)}W.k.2k=\'1j\';1X=5q}p 4f(){1f=\'F\';2c=\'2H\';1y()}p 1y(){1K.k.G=\'1j\';1f=\'F\';3N=0;1K.k.y=\'K\'}p 4e(){1f=\'o\';1K.k.2k=(O((1B-z)/2)+18+2X-I)+\'q\';1K.k.3l=(O((1r-H-1g)/2)+4+2E-I)+\'q\';6M=U 1F.5a(1K,{1G:4R,1T:p(){3N=0;1K.k.G=3N+\'q\';l(1f==\'o\'){l(x==u.B-1){1n(1)}t{1n(x+1)}}}});6M.1I(0,z+(2*I)-36)}p 6A(){l(z>1B-(2*(V+I+1o+1C))){z=1B-(2*(V+I+1o+1C));H=45.46(z/3O)}l(H>1r-(2*(V+I+1o+1C))-1g){H=1r-(2*(V+I+1o+1C))-1g;z=45.46(3O*H)}v}p 4Z(){4j=O(2X-(z+(2*(V+I+1o)))/2);4k=O(2E-(4h+H+1g+(2*(V+I+1o)))/2);2u.k.5g=4j+\'q\';2u.k.65=(4k-(3M/2))+\'q\';v}p 3T(){l(x>1){l(3d==\'o\'){6N=U 2W();6N.C=u[x-1][0]}l(2F==\'o\'){1l.T+=\'<a 1t="2F" 1q="l(1f==\\\'o\\\'){1y();}1n(\'+(x-1)+\')" 1h="&83;">\'+4m+\'</a>\'}1R.k.y=\'16\';1R.1q=p(){l(1f==\'o\'){1y()}1n(x-1);v M}}l(x<u.B-1){l(3d==\'o\'){6O=U 2W();6O.C=u[x+1][0]}l(2F==\'o\'){1l.T+=\'<a 1t="2F" 1q="l(1f==\\\'o\\\'){1y();}1n(\'+(x+1)+\')" 1h="&84;">\'+4n+\'</a>\'}1S.k.y=\'16\';1S.1q=p(){l(1f==\'o\'){1y()}1n(x+1);v M}}v}p 3x(){l(L[0]==\'1w\'||u.B>2){l(3Z){58(3Z)}}3G=\'o\';2O=3H;55();1L.k.G=\'1j\';1v.k.G=\'1j\';1p.k.G=\'1j\';1p.k.R=\'1j\';1p.k.w=\'S\';2T.k.w=\'S\';4f();W.T=\'\';1l.T=\'\';D.C=P+\'2y.19\';2h=z;2i=H;2V.k.R=H+(2*I)+\'q\';D.k.y=\'K\';2u.k.w=\'S\';4L.T=\'\';3Y();6P();2m.k.w=\'S\';2n.k.w=\'S\';1R.k.y=\'K\';1S.k.y=\'K\';1Z.k.w=\'S\';57();v}p 6P(){4H.1I(2I,0);l(2N==\'o\'){6Q()}l(2M==\'o\'){6R()}v}p 6s(){Z.1W=0;Z.1V=0;l(Q.47&&Q.5h){1W=Q.47+Q.5h;1V=Q.4Y+Q.4X}t l(m.X.5i>m.X.3r){1W=m.X.5i;1V=m.X.6S}t{1W=m.X.3r;1V=m.X.85}l(14.15.Y("2x")!=-1||14.15.Y("3p")!=-1){1W=m.X.5i;1V=m.X.6S}l(14.15.Y("3W")!=-1||14.15.Y("6u")!=-1){1W=1B+Q.5h;1V=1r+Q.4X}v}p 6r(){Z.1B=0;Z.1r=0;l(m.1J&&(m.1J.3t||m.1J.2Y)){1B=m.1J.3t;1r=m.1J.2Y}t l(3j(Q.47)==\'6T\'){1B=Q.47;1r=Q.4Y}t l(m.X&&(m.X.3t||m.X.2Y)){1B=m.X.3t;1r=m.X.2Y;v}l(14.15.Y("3p")!=-1){1B=m.1J.3t;1r=m.1J.2Y}l(m.6U!=3k){l(m.6U.6l(\'86\')&&(14.15.Y("3W")!=-1||14.15.Y("3p")!=-1||14.15.Y("87")!=-1)){1r=m.X.2Y}}v}p 6t(){Z.2X=0;Z.2E=0;l(3j(Q.6V)==\'6T\'){2E=Q.6V;2X=Q.88}t l(m.X&&(m.X.48||m.X.49)){2E=m.X.49;2X=m.X.48}t l(m.1J&&(m.1J.48||m.1J.49)){2E=m.1J.49;2X=m.1J.48}v}p 6q(){E s,i,j;E a=U 2C();a.23(m.r(\'4v\'));a.23(m.r(\'4A\'));a.23(m.r(\'4z\'));a.23(m.r(\'4x\'));a.23(m.r(\'4y\'));1z(i=0;i<a.B;i++){s=a[i].17(\'C\');l(s.89().Y(".1e")!=-1){a[i].C=P+\'2y.19\';a[i].k.1d+="24:26.28.29(C=\'"+s+"\', 2a=8a);"}}m.r(\'4t\').k.1d="24:26.28.29(C=\'"+P+"/6i.1e\', 2a=\'5j\');";m.r(\'4s\').k.1d="24:26.28.29(C=\'"+P+"/6j.1e\', 2a=\'3u\');";m.r(\'4u\').k.1d="24:26.28.29(C=\'"+P+"/6k.1e\', 2a=\'3u\');";m.r(\'2w\').k.1d="24:26.28.29(C=\'"+P+"/6h.1e\', 2a=\'5j\');";m.r(\'2v\').k.1d="24:26.28.29(C=\'"+P+"/6g.1e\', 2a=\'5j\');";m.r(\'4C\').k.1d="24:26.28.29(C=\'"+P+"/6d.1e\', 2a=\'3u\');";m.r(\'4B\').k.1d="24:26.28.29(C=\'"+P+"/6e.1e\', 2a=\'3u\');";m.r(\'4D\').k.1d="24:26.28.29(C=\'"+P+"/6f.1e\', 2a=\'3u\');";m.r(\'4t\').k.1U="K";m.r(\'4s\').k.1U="K";m.r(\'4u\').k.1U="K";m.r(\'2w\').k.1U="K";m.r(\'2v\').k.1U="K";m.r(\'4C\').k.1U="K";m.r(\'4B\').k.1U="K";m.r(\'4D\').k.1U="K"}p 4U(){E a=m.2j("6W");1z(i=0;i!=a.B;i++){a[i].k.w="S"}}p 6Q(){E a=m.2j("6W");1z(i=0;i!=a.B;i++){a[i].k.w="1c"}}p 4V(){E a=m.2j("6X");1z(i=0;i<a.B;i++){a[i].k.w="S"}E b=m.2j("6Y");1z(i=0;i<b.B;i++){b[i].k.w="S"}}p 6R(){E a=m.2j("6X");1z(i=0;i<a.B;i++){a[i].k.w="1c"}E b=m.2j("6Y");1z(i=0;i<b.B;i++){b[i].k.w="1c"}}p 6Z(a){l(14.15.Y("3p")!=-1){a=-a}l(u.B>2){l(a>0&&x>1){l(1f==\'o\'){1y()}1n(x-1)}l(a<0&&x<u.B-1){l(1f==\'o\'){1y()}1n(x+1)}}}p 5k(a){E b=2b=="o";E c=0;l(!a)a=Q.4a;l(a.71){c=a.71/8b;l(Q.8c)c=-c}t l(a.72){c=-a.72/3}l(c&&b)6Z(c);l(a.73&&!2O)a.73();a.8d=2O}l(Q.2R)Q.2R(\'8e\',5k,M);Q.74=m.74=5k;',62,511,'||||||||||||||||||||style|if|document||on|function|px|getElementById||else|CB_Gallery|return|visibility|CB_ActImgId|display|CB_ImgWidth|id|length|src|CB_Img|var|off|width|CB_ImgHeight|CB_ImgBorder|div|none|CB_Rel|false|CB_Links|parseInt|CB_PicDir|window|height|hidden|innerHTML|new|CB_RoundPix|CB_Txt1|body|indexOf|this|||||navigator|userAgent|block|getAttribute||gif|td|CB_HideContent|visible|filter|png|CB_SSTimer|CB_TextH|alt|opacity|0px|CB_HTxt|CB_Txt2|CB_Clicked|CB_LoadImage|CB_Padd|CB_ImgHd|onclick|BrSizeY|img|class|appendChild|CB_TxtL|clearbox|CB_Animation|CB_SlideShowJump|for|rel|BrSizeX|CB_WinPadd|temp|title|CB_effektek|idotartam|substring|sajat|documentElement|CB_SlideB|CB_Txt|CB_iFr|createTextNode|CB_PadT|CB_SlideS|CB_SlideP|CB_Prv|CB_Nxt|halefutott|backgroundImage|DocSizeY|DocSizeX|CB_STi|CB_AnimSpeed|CB_LoadingImg|onmouseover|null|split|push|progid||DXImageTransform||Microsoft|AlphaImageLoader|sizingMethod|CB_ClearBox|CB_SS|CB_HideOpacitySpeed|CB_ImgOpacitySpeed|CB_ImgTextFade|CB_AllThumbsWidth|CB_ImgWidthOld|CB_ImgHeightOld|getElementsByTagName|left|alpha|CB_NavP|CB_NavN|href|span|CB_AllowedToRun|CB_ImgMinWidth|CB_ImgMinHeight|CB_ImgWidthOrig|CB_Win|CB_Left|CB_Right|MSIE|blank|CB_Thm|Atlatszosag|CB_Cls|Array|tnhref|DocScrY|CB_TextNav|CB_IsAnimating|start|CB_HideOpacity|CB_TextOpacitySpeed|CB_FontSize|CB_SlShowTime|CB_FlashHide|CB_SelectsHide|CB_ScrollEnabled|CB_ImgHeightOrig|CB_preImages|addEventListener|tr|CB_ShTh|elrejt|CB_ImgCont|Image|DocScrX|clientHeight|CB_Show||CB_BodyMarginLeft||CB_BodyMarginRight|CB_BodyMarginTop|CB_BodyMarginBottom|||CB_ShowImgURL||CB_SimpleDesign|CB_FontSize2|CB_ImgNum|CB_Preload|CB_ShowGalName|CB_AllowExtFunct|CB_ActThumbSrc|CB_Header|CB_Footer|typeof|undefined|top|CB_Thm2|HTML|CB_CloseOnHON|Opera|100|offsetWidth|tempX|clientWidth|crop|CB_CheckDuplicates|double|CB_Close|warp|CB_NoThumbnails|CB_CloseOnH|CB_NavTextImgPrv|CB_NavTextImgNxt|CB_NavTextImgFull|CB_NavTextImgDL|CB_FullSize|CB_Break|true|CB_ScrollTimer|CB_IEShowBug|CB_BodyMarginX|CB_BodyMarginY|FF_ScrollbarBug|CB_SlideBW|CB_ImgRate|CB_Count|CB_Loaded|CB_BtmNav|CB_NavTextFull|CB_PrevNext|CB_ShowImage|CB_HideThumbs|Firefox|charAt|CB_TxtLShow|CB_ImgLoadTimer|CB_animWidth|CB_animHeight|CB_Sep|CB_preThumbs|CB_preThumbs2|Math|round|innerWidth|scrollLeft|scrollTop|event|CB_SSStart|CB_SSPause|pause|CB_SlideShow|CB_SlideShowStop|10000|CB_ieRPBug|CB_ie6RPBug|CB_MarginL|CB_MarginT|IE|CB_NavTextPrv|CB_NavTextNxt|CB_NavTextDL|CB_ShowTh|CB_All|createElement|CB_TopLeft|CB_Top|CB_TopRight|CB_CloseWindow|CB_Thumbs|CB_NavPrev|CB_NavNext|CB_SlideShowP|CB_SlideShowS|CB_BtmLeft|CB_Btm|CB_BtmRight|HideDocumentFadeEffectiFr|CB_AnimatePlease|HideDocumentFadeEffect|HideDocumentFadeEffect2|fontFamily|fontWeight|fontSize|CB_iFrC|TxtFadeEffect|ImgFadeEffect|CB_PrvNxt|CB_ClickIMG|CB_ClickURL|CB_SlShowTimer|childNodes|CB_SetAllPositions|CB_HideSelect|CB_HideFlash|CB_HideDocument|scrollMaxY|innerHeight|CB_SetMargins||iFrFadeEffect||CB_NewAndLoad||CB_ScrollTextStop|CB_CheckLoaded|CB_CloseOnHOFF|clearTimeout|CB_WindowResizeXY|szelesseg|CB_AfterResizeHTML|CB_ImageFade|CB_TxtLPos|CB_ScrollT|CB_ScrollText|marginLeft|scrollMaxX|scrollWidth|scale|scroll_wheel|CB_KeyPress|which|600|normal|1000|CB_STii|CB_Content|btm_prev|btm_next|btm_max|btm_dl|OnLoad|attachEvent|CB_Init|setAttribute|CB_HiddenText|CB_ContentHide|CB_SlideShowBar|table|CB_Window|CB_Padding|CB_ImgContainer|CB_NavTextClose|CB_PictureClose|CB_iFrCont|CB_Thumbs2|CB_LoadingImage|CB_PictureLoading|CB_Image|CB_PicturePrev|CB_PictureNext|CB_ImgHide|CB_NavTextStop|CB_PicturePause|CB_NavTextStart|CB_PictureStart|CB_Prev|CB_Next|CB_Text|CB_T1|CB_T2|CB_TL||backgroundColor|url|onmouseout|marginTop|CB_Font|CB_FontWeight|color|ImgFadeEffect2|CB_ShowThumbs|getMouseXY|noprv|s_btm|s_btmleft|s_btmright|s_left|s_right|s_top|s_topleft|s_topright|match|alert|ClearBox|ERROR|in|CB_pngFixIE|getBrowserSize|getDocumentSize|getScrollPosition|Netscape|iframe|CB_iFrame|CB_NewWindow|CB_GetImageSize|setTimeout|CB_FitToBrowser|CB_WindowResizeX|CB_WindowResizeY|magassag|CB_AfterLoadedHTML|CB_ExternalFunction|textAlign|CB_ImgFadeIn|CB_ImgNumBracket|target|_blank|CB_CheckThumbs|CB_ssbarWidth|PreloadPrv|PreloadNxt|CB_ShowDocument|CB_ShowSelect|CB_ShowFlash|scrollHeight|number|compatMode|pageYOffset|select|object|embed|scroll_handle||wheelDelta|detail|preventDefault|onmousewheel||CB_version|keyCode|String|fromCharCode|300|250|CB_ImgFadeNum|CB_pngie|CB_ResizeTimer|all|captureEvents|Event|MOUSEMOVE|load|onkeypress|position|static|CB_RoundPixBugFix|item|cellspacing|cellpadding|CB_Body|valign|align|loading|padding|fff|CB_HideColor|border|solid|CB_ImgBorderColor|CB_FontColor|CB_Font2|CB_FontWeight2|CB_FontColor2|onmousemove|white|CB_URL|nClearBox|gallery|name|cannot|be|className|CB_TnThumbs|click|Bad|REL|attribute|Windows|while|screen|frameborder|complete|center|_box|CB_ThumbsImg|clientX|pageX|lt|gt|offsetHeight|Back|Safari|pageXOffset|toLowerCase|image|120|opera|returnValue|DOMMouseScroll'.split('|'),0,{}))