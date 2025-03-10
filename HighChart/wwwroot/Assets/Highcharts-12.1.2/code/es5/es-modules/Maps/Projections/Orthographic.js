/* *
 * Orthographic projection
 * */
'use strict';
/* *
 *
 *  Constants
 *
 * */
var deg2rad = Math.PI / 180, scale = 63.78460826781007;
/* *
 *
 *  Class
 *
 * */
var Orthographic = /** @class */ (function () {
    function Orthographic() {
        /* *
         *
         *  Properties
         *
         * */
        this.antimeridianCutting = false;
        this.bounds = {
            x1: -scale,
            x2: scale,
            y1: -scale,
            y2: scale
        };
    }
    /* *
     *
     *  Functions
     *
     * */
    Orthographic.prototype.forward = function (lonLat) {
        var lonDeg = lonLat[0], latDeg = lonLat[1], lat = latDeg * deg2rad, xy = [
            Math.cos(lat) * Math.sin(lonDeg * deg2rad) * scale,
            Math.sin(lat) * scale
        ];
        if (lonDeg < -90 || lonDeg > 90) {
            xy.outside = true;
        }
        return xy;
    };
    Orthographic.prototype.inverse = function (xy) {
        var x = xy[0] / scale, y = xy[1] / scale, z = Math.sqrt(x * x + y * y), c = Math.asin(z), cSin = Math.sin(c), cCos = Math.cos(c);
        return [
            Math.atan2(x * cSin, z * cCos) / deg2rad,
            Math.asin(z && y * cSin / z) / deg2rad
        ];
    };
    return Orthographic;
}());
/* *
 *
 *  Default Export
 *
 * */
export default Orthographic;
