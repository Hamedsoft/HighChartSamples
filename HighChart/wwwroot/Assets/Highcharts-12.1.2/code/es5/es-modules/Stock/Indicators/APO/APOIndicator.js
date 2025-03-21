/* *
 *
 *  License: www.highcharts.com/license
 *
 *  !!!!!!! SOURCE GETS TRANSPILED BY TYPESCRIPT. EDIT TS FILE ONLY. !!!!!!!
 *
 * */
'use strict';
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import SeriesRegistry from '../../../Core/Series/SeriesRegistry.js';
var EMAIndicator = SeriesRegistry.seriesTypes.ema;
import U from '../../../Core/Utilities.js';
var extend = U.extend, merge = U.merge, error = U.error;
/* *
 *
 *  Class
 *
 * */
/**
 * The APO series type.
 *
 * @private
 * @class
 * @name Highcharts.seriesTypes.apo
 *
 * @augments Highcharts.Series
 */
var APOIndicator = /** @class */ (function (_super) {
    __extends(APOIndicator, _super);
    function APOIndicator() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    /* *
     *
     *  Functions
     *
     * */
    APOIndicator.prototype.getValues = function (series, params) {
        var periods = params.periods, index = params.index, 
        // 0- date, 1- Absolute price oscillator
        APO = [], xData = [], yData = [];
        var oscillator, i;
        // Check if periods are correct
        if (periods.length !== 2 || periods[1] <= periods[0]) {
            error('Error: "APO requires two periods. Notice, first period ' +
                'should be lower than the second one."');
            return;
        }
        // Shorter Period EMA
        var SPE = _super.prototype.getValues.call(this, series, {
            index: index,
            period: periods[0]
        });
        // Longer Period EMA
        var LPE = _super.prototype.getValues.call(this, series, {
            index: index,
            period: periods[1]
        });
        // Check if ema is calculated properly, if not skip
        if (!SPE || !LPE) {
            return;
        }
        var periodsOffset = periods[1] - periods[0];
        for (i = 0; i < LPE.yData.length; i++) {
            oscillator = (SPE.yData[i + periodsOffset] -
                LPE.yData[i]);
            APO.push([LPE.xData[i], oscillator]);
            xData.push(LPE.xData[i]);
            yData.push(oscillator);
        }
        return {
            values: APO,
            xData: xData,
            yData: yData
        };
    };
    /* *
     *
     *  Static Properties
     *
     * */
    /**
     * Absolute Price Oscillator. This series requires the `linkedTo` option to
     * be set and should be loaded after the `stock/indicators/indicators.js`.
     *
     * @sample {highstock} stock/indicators/apo
     *         Absolute Price Oscillator
     *
     * @extends      plotOptions.ema
     * @since        7.0.0
     * @product      highstock
     * @excluding    allAreas, colorAxis, joinBy, keys, navigatorOptions,
     *               pointInterval, pointIntervalUnit, pointPlacement,
     *               pointRange, pointStart, showInNavigator, stacking
     * @requires     stock/indicators/indicators
     * @requires     stock/indicators/apo
     * @optionparent plotOptions.apo
     */
    APOIndicator.defaultOptions = merge(EMAIndicator.defaultOptions, {
        /**
         * Parameters used in calculation of Absolute Price Oscillator
         * series points.
         *
         * @excluding period
         */
        params: {
            period: void 0, // Unchangeable period, do not inherit (#15362)
            /**
             * Periods for Absolute Price Oscillator calculations.
             *
             * @type    {Array<number>}
             * @default [10, 20]
             * @since   7.0.0
             */
            periods: [10, 20]
        }
    });
    return APOIndicator;
}(EMAIndicator));
extend(APOIndicator.prototype, {
    nameBase: 'APO',
    nameComponents: ['periods']
});
SeriesRegistry.registerSeriesType('apo', APOIndicator);
/* *
 *
 *  Default Export
 *
 * */
export default APOIndicator;
/* *
 *
 *  API Options
 *
 * */
/**
 * An `Absolute Price Oscillator` series. If the [type](#series.apo.type) option
 * is not specified, it is inherited from [chart.type](#chart.type).
 *
 * @extends   series,plotOptions.apo
 * @since     7.0.0
 * @product   highstock
 * @excluding allAreas, colorAxis, dataParser, dataURL, joinBy, keys,
 *            navigatorOptions, pointInterval, pointIntervalUnit,
 *            pointPlacement, pointRange, pointStart, showInNavigator, stacking
 * @requires  stock/indicators/indicators
 * @requires  stock/indicators/apo
 * @apioption series.apo
 */
''; // To include the above in the js output
