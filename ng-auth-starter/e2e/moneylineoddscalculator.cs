   function roundTo(n, digits) {
            var negative = false;
            if (digits === undefined) {
                digits = 0;
            }
            if (n < 0) {
                negative = true;
                n = n * -1;
            }
            var multiplicator = Math.pow(10, digits);
            n = parseFloat((n * multiplicator).toFixed(11));
            n = (Math.round(n) / multiplicator).toFixed(2);
            if (negative) {
                n = (n * -1).toFixed(2);
            }
            return n;
        }

        // Basic Odds Functions 
        function calcDecimal2odds(decimal) {
            var num = decimal;
            if (decimal <= 2) //negative odds
            {
                num = Math.round((-100) / (decimal - 1));
            }
            else //positive odds
            {
                num = Math.round((decimal - 1) * 100);
            }
            return num;
        }
        function calcOdds2decimal(odds) {
            var num = odds;
            if (odds <= 100) //negative odds
            {
                num = (100 / -odds) + 1;
                num = roundTo(num, 2)
            }
            else //positive odds
            {
                num = (odds / 100) + 1;
                num = roundTo(num, 2)
            }
            return num;
        }

        function calcDecimal2IP(decimal) {
            var num = decimal;
            num = Math.round(100 * (1 / decimal)) + "%";
            return num;
        }
        function calcOdds2IP(odds) {
            var num = odds;
            if (odds <= 100) //negative odds
            {
                //num=Math.round(100*(1/odds))+"%";
                num = -100 * (odds / (-odds + 100));
                num = roundTo(num, 0);
            }
            else {
                //num=Math.round(100*(1/odds))+"%";
                num = 100 * (odds / (odds + 100));
                num = roundTo(num, 0);
            }
            return num;
        }

        // Odds Converter Page
        function propsodds(theseodds, theseoddsid) {
            var oddstype = theseoddsid.replace('odds', ''); var usodds = document.getElementById('usodds'); var decodds = document.getElementById('decodds'); var fracodds = document.getElementById('fracodds'); var probodds = document.getElementById('probodds'); var hkodds = document.getElementById('hkodds'); var indodds = document.getElementById('indodds'); var malodds = document.getElementById('malodds'); var myDec; if (theseodds.match(/^Ev.*$/i)) { theseodds = 2; oddstype = 'dec'; }
            if (oddstype == 'us') { myDec = US2dec(theseodds); }
            else if (oddstype == 'dec') {
                if (1 * theseodds < 0) { theseodds = Math.abs(1 * theseodds); }
                if (1 * theseodds < 1) { theseodds = 1; }
                myDec = parseFloat(theseodds).toFixed(4);
            } else if (oddstype == 'frac') {
                var sThisOdds = "" + theseodds; if (!sThisOdds.match(/\//)) { sThisOdds = sThisOdds + '/1'; }
                myDec = frac2dec(sThisOdds);
            } else if (oddstype == 'prob') { var sThisOdds = "" + theseodds; theseodds = fmtNumber(sThisOdds); if (theseodds >= 1) theseodds /= 100; myDec = prob2dec(theseodds); } else if (oddstype == 'hk') { myDec = HK2dec(theseodds); } else if (oddstype == 'ind') { myDec = Indo2dec(theseodds); } else if (oddstype == 'mal') { myDec = Malay2dec(theseodds); }
            bet.value = bet.value;
            usodds.value = dec2US(myDec);
            decodds.value = myDec;
            fracodds.value = dec2frac(myDec);
            probodds.value = dec2prob(myDec);
            hkodds.value = dec2HK(myDec);
            indodds.value = dec2Indo(myDec);
            malodds.value = dec2Malay(myDec);
            winnings.value = bet.value * (myDec - 1);

        }
        function dec2US(myDec) {
            var myUS;
            myDec = parseFloat(myDec);
            if (myDec <= 1 || myDec == NaN) { myUS = NaN; }
            else if (myDec < 2) { myUS = -100 / (myDec - 1); }
            else { myUS = (myDec - 1) * 100; }
            return (myUS > 0 ? "+" : "") + Math.round(myUS * 100) / 100;
        }
        function US2dec(myUS) {
            var myDec;
            myUS = parseFloat(myUS);
            if (Math.abs(myUS) < 100 || myUS == NaN) { myDec = NaN; }
            else if (myUS > 0) { myDec = 1 + myUS / 100; }
            else { myDec = 1 - 100 / myUS; }
            return myDec.toFixed(4);
        }
        function dec2frac(dec) {
            dec = parseFloat(dec - 1);
            var myBestFrac = Math.round(dec) + "/" + 1; var myBestFracVal = Math.round(dec);
            var myBestErr = Math.abs(myBestFracVal - dec);
            for (i = 2; i <= 200; i++) {
                var myFracVal = Math.round(dec * i) / i;
                var myErr = Math.abs(myFracVal - dec);
                if (myErr < myBestErr) {
                    myBestFrac = Math.round(dec * i) + "/" + i; myBestFracVal = myFracVal;
                    if (myErr == 0) break; myBestErr = myErr;
                }
            }
            return (myBestFrac);
        }
        function frac2dec(frac) {
            var myArr = frac.split(/\//);
            myArr[1] = myArr[1] == undefined ? 1 : myArr[1];
            return ((myArr[0] / myArr[1] + 1).toFixed(4));
        }
        function prob2dec(prob) { return (1 / fmtNumber(prob)).toFixed(4); }
        function dec2prob(dec) { return fmtPercent(1 / dec); }
        function HK2dec(myHK) {
            var myDec; myHK = parseFloat(myHK);
            if (myHK <= 0 || myHK == NaN) { myDec = NaN; }
            else { myDec = (myHK + 1); }
            return myDec.toFixed(4);
        }
        function dec2HK(myDec) {
            var myHK; myDec = parseFloat(myDec);
            if (myDec <= 1 || myDec == NaN) { myHK = NaN; }
            else { myHK = (myDec - 1); }
            return myHK.toFixed(4);
        }
        function Indo2dec(myIndo) {
            var myDec; myIndo = parseFloat(myIndo);
            if (myIndo == NaN || Math.abs(myIndo) < 1) { myDec = NaN; }
            else if (myIndo >= 1) { myDec = (myIndo + 1); }
            else { myDec = 1 - 1 / myIndo; }
            return myDec.toFixed(4);
        }
        function dec2Indo(myDec) {
            var myIndo; myDec = parseFloat(myDec);
            if (myDec <= 1 || myDec == NaN) { myIndo = NaN; }
            else if (myDec >= 2) { myIndo = (myDec - 1); }
            else { myIndo = 1 / (1 - myDec); }
            return myIndo.toFixed(4);
        }
        function Malay2dec(myMalay) {
            var myDec; myMalay = parseFloat(myMalay);
            if (myMalay == NaN || myMalay > 1 || myMalay == 0) { myDec = NaN; }
            else if (myMalay > 0) { myDec = (myMalay + 1); }
            else { myDec = 1 - 1 / myMalay; }
            return myDec.toFixed(4);
        }
        function dec2Malay(myDec) {
            var myMalay; myDec = parseFloat(myDec);
            if (myDec <= 1 || myDec == NaN) { myMalay = NaN; }
            else if (myDec <= 2) { myMalay = (myDec - 1); }
            else { myMalay = 1 / (1 - myDec); }
            return myMalay.toFixed(4);
        }
        function fmtNumber(myString) {
            myString = "" + myString; myString = myString.replace(/\$/g, "");
            myNum = myString.replace(/\,/g, "");
            if (myString.match(/\%$/g, "")) {
                myNum = myString.replace(/\%$/g, "")
                mynum = parseFloat(myNum) / 100;
            }
            return (1 * myNum);
        }
        function fmtPercent(myNum) {
            if (("" + myNum).match(/\%$/g, "")) { myNum = myNum.replace(/\%$/g, ""); myNum /= 100; }
            return (((myNum * 100).toFixed(2)) + "%");
        }
        function addCommas(nStr) {
            nStr += ''; var x = nStr.split('.');
            var x1 = x[0]; var x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) { x1 = x1.replace(rgx, '$1' + ',' + '$2'); }
            return x1 + x2;
        }