"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.OperacionService = void 0;
var OperacionService = /** @class */ (function () {
    function OperacionService(_http) {
        this._http = _http;
        this.urlBase = 'https://localhost:5001/api/operacion/';
    }
    OperacionService.prototype.GetTopTen = function (_id) {
        return this._http.get(this.urlBase + 'gettopten/' + _id);
    };
    return OperacionService;
}());
exports.OperacionService = OperacionService;
//# sourceMappingURL=operacion.service.js.map