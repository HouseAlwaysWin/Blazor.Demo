(function(){
    window.popupJsFunctions ={
        populateDiv:function(element){
            popupJsFunctions.getHTML('/Counter',function(response){
                element.innerHTML = response.documentElement.innerHTML;
            });
        },

        getHTML:function(url,callback){
            if(!window.XMLHttpRequest)return;
            var xhr = new XMLHttpRequest();

            xhr.onload = function(){
                if(callback && typeof(callback) === 'function'){
                    callback(this.responseXML);
                }
            };

            xhr.open('GET',url);
            xhr.responseType = 'document';
            xhr.send();
        }
    }
})();