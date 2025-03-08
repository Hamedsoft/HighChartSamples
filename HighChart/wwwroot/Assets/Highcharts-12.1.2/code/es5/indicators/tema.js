!/**
 * Highstock JS v12.1.2 (2025-01-09)
 * @module highcharts/indicators/tema
 * @requires highcharts
 * @requires highcharts/modules/stock
 *
 * Indicator series type for Highcharts Stock
 *
 * (c) 2010-2024 Rafal Sebestjanski
 *
 * License: www.highcharts.com/license
 */function(e,t){"object"==typeof exports&&"object"==typeof module?module.exports=t(require("highcharts"),require("highcharts").SeriesRegistry):"function"==typeof define&&define.amd?define("highcharts/indicators/tema",[["highcharts/highcharts"],["highcharts/highcharts","SeriesRegistry"]],t):"object"==typeof exports?exports["highcharts/indicators/tema"]=t(require("highcharts"),require("highcharts").SeriesRegistry):e.Highcharts=t(e.Highcharts,e.Highcharts.SeriesRegistry)}(this,function(e,t){return function(){"use strict";var r,o={512:function(e){e.exports=t},944:function(t){t.exports=e}},i={};function n(e){var t=i[e];if(void 0!==t)return t.exports;var r=i[e]={exports:{}};return o[e](r,r.exports,n),r.exports}n.n=function(e){var t=e&&e.__esModule?function(){return e.default}:function(){return e};return n.d(t,{a:t}),t},n.d=function(e,t){for(var r in t)n.o(t,r)&&!n.o(e,r)&&Object.defineProperty(e,r,{enumerable:!0,get:t[r]})},n.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)};var l={};n.d(l,{default:function(){return d}});var s=n(944),u=n.n(s),a=n(512),c=n.n(a),h=(r=function(e,t){return(r=Object.setPrototypeOf||({__proto__:[]})instanceof Array&&function(e,t){e.__proto__=t}||function(e,t){for(var r in t)t.hasOwnProperty(r)&&(e[r]=t[r])})(e,t)},function(e,t){function o(){this.constructor=e}r(e,t),e.prototype=null===t?Object.create(t):(o.prototype=t.prototype,new o)}),p=c().seriesTypes.ema,f=u().correctFloat,v=u().isArray,g=u().merge,y=function(e){function t(){return null!==e&&e.apply(this,arguments)||this}return h(t,e),t.prototype.getEMA=function(t,r,o,i,n,l){return e.prototype.calculateEma.call(this,l||[],t,void 0===n?1:n,this.EMApercent,r,void 0===i?-1:i,o)},t.prototype.getTemaPoint=function(e,t,r,o){return[e[o-3],f(3*r.level1-3*r.level2+r.level3)]},t.prototype.getValues=function(t,r){var o,i,n,l,s=r.period,u=2*s,a=3*s,c=t.xData,h=t.yData,p=h?h.length:0,f=[],g=[],y=[],d=[],x=[],m={},_=-1,A=0,O=0;if(this.EMApercent=2/(s+1),!(p<3*s-2)){for(v(h[0])&&(_=r.index?r.index:0),O=(A=e.prototype.accumulatePeriodPoints.call(this,s,_,h))/s,A=0,n=s;n<p+3;n++)n<p+1&&(m.level1=this.getEMA(h,o,O,_,n)[1],d.push(m.level1)),o=m.level1,n<u?A+=m.level1:(n===u&&(O=A/s,A=0),m.level1=d[n-s-1],m.level2=this.getEMA([m.level1],i,O)[1],x.push(m.level2),i=m.level2,n<a?A+=m.level2:(n===a&&(O=A/s),n===p+1&&(m.level1=d[n-s-1],m.level2=this.getEMA([m.level1],i,O)[1],x.push(m.level2)),m.level1=d[n-s-2],m.level2=x[n-2*s-1],m.level3=this.getEMA([m.level2],m.prevLevel3,O)[1],(l=this.getTemaPoint(c,a,m,n))&&(f.push(l),g.push(l[0]),y.push(l[1])),m.prevLevel3=m.level3));return{values:f,xData:g,yData:y}}},t.defaultOptions=g(p.defaultOptions),t}(p);c().registerSeriesType("tema",y);var d=u();return l.default}()});