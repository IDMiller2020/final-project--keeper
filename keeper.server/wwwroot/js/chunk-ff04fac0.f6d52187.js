(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-ff04fac0"],{"30cf":function(e,t,c){},"7a1b":function(e,t,c){"use strict";c("30cf")},e542:function(e,t,c){"use strict";c.r(t);var a=c("7a23");const l=Object(a["I"])("data-v-1975a70c");Object(a["t"])("data-v-1975a70c");const n={class:"container-fluid"},r={class:"row"},o={class:"col-12"},s={class:"about text-center"},i={class:"row"},u={class:"col-12"},b=Object(a["g"])("h2",null,"Create A Keep",-1),p={class:"form-group"},d=Object(a["g"])("label",{for:"keepTitle"},"Keep Title",-1),g={class:"form-group"},j=Object(a["g"])("label",{for:"keepImageUrl"},"Image Url",-1),O={class:"form-group"},m=Object(a["g"])("label",{for:"description"},"Description",-1),f=Object(a["g"])("button",{type:"submit",class:"btn btn-primary my-4"}," Create ",-1),w={class:"row"},v={class:"col-12"},V=Object(a["g"])("h2",{class:"mt-4"}," Add A Vault ",-1),y={class:"form-group"},K=Object(a["g"])("label",{for:"vaultTitle"},"Vault Title",-1),U={class:"form-group"},h=Object(a["g"])("label",{for:"vaultImageUrl"},"Image Url",-1),k={class:"form-group"},C=Object(a["g"])("label",{for:"description"},"Description",-1),I={class:"form-check"},T=Object(a["g"])("label",{class:"form-check-label",for:"defaultCheck1"}," Private ",-1),G=Object(a["g"])("button",{type:"submit",class:"btn btn-primary my-4"}," Create ",-1);Object(a["r"])();const A=l((e,t,c,l,A,x)=>(Object(a["q"])(),Object(a["d"])("div",n,[Object(a["g"])("div",r,[Object(a["g"])("div",o,[Object(a["g"])("div",s,[Object(a["g"])("h1",null,"Welcome "+Object(a["z"])(l.account.name),1),Object(a["g"])("img",{class:"rounded",src:l.account.picture,alt:""},null,8,["src"]),Object(a["g"])("p",null,Object(a["z"])(l.account.email),1)])])]),Object(a["g"])("div",i,[Object(a["g"])("div",u,[b,Object(a["g"])("form",{onSubmit:t[4]||(t[4]=Object(a["H"])((...e)=>l.createKeep&&l.createKeep(...e),["prevent"]))},[Object(a["g"])("div",p,[d,Object(a["G"])(Object(a["g"])("input",{type:"title",class:"form-control",id:"keepTitleInput","aria-describedby":"keepTitle","onUpdate:modelValue":t[1]||(t[1]=e=>l.state.newKeep.name=e)},null,512),[[a["C"],l.state.newKeep.name]])]),Object(a["g"])("div",g,[j,Object(a["G"])(Object(a["g"])("input",{type:"imageUrl",class:"form-control",id:"imageUrlInput","onUpdate:modelValue":t[2]||(t[2]=e=>l.state.newKeep.img=e)},null,512),[[a["C"],l.state.newKeep.img]])]),Object(a["g"])("div",O,[m,Object(a["G"])(Object(a["g"])("textarea",{class:"form-control",id:"description",rows:"3","onUpdate:modelValue":t[3]||(t[3]=e=>l.state.newKeep.description=e)},null,512),[[a["C"],l.state.newKeep.description]])]),f],32)])]),Object(a["g"])("div",w,[Object(a["g"])("div",v,[V,Object(a["g"])("form",{onSubmit:t[9]||(t[9]=Object(a["H"])((...e)=>l.createVault&&l.createVault(...e),["prevent"]))},[Object(a["g"])("div",y,[K,Object(a["G"])(Object(a["g"])("input",{type:"title",class:"form-control",id:"vaultTitleInput","aria-describedby":"vaultTitle","onUpdate:modelValue":t[5]||(t[5]=e=>l.state.newVault.name=e)},null,512),[[a["C"],l.state.newVault.name]])]),Object(a["g"])("div",U,[h,Object(a["G"])(Object(a["g"])("input",{type:"imageUrl",class:"form-control",id:"imageUrlInput","onUpdate:modelValue":t[6]||(t[6]=e=>l.state.newVault.img=e)},null,512),[[a["C"],l.state.newVault.img]])]),Object(a["g"])("div",k,[C,Object(a["G"])(Object(a["g"])("textarea",{class:"form-control",id:"description",rows:"3","onUpdate:modelValue":t[7]||(t[7]=e=>l.state.newVault.description=e)},null,512),[[a["C"],l.state.newVault.description]])]),Object(a["g"])("div",I,[Object(a["G"])(Object(a["g"])("input",{class:"form-check-input",type:"checkbox",value:"",id:"defaultCheck1","onUpdate:modelValue":t[8]||(t[8]=e=>l.state.newVault.isPrivate=e)},null,512),[[a["B"],l.state.newVault.isPrivate]]),T]),G],32)])])])));var x=c("83fc"),P=c("6c96"),S=c("d10d"),z={name:"Account",setup(){const e=Object(a["u"])({newKeep:{},newVault:{}});return{state:e,account:Object(a["b"])(()=>x["AppState"].account),async createKeep(){try{await P["a"].createKeep(e.newKeep),e.newKeep={}}catch(t){console.error(t)}},async createVault(){try{await S["a"].createVault(e.newVault),e.newVault={}}catch(t){console.error(t)}}}}};c("7a1b");z.render=A,z.__scopeId="data-v-1975a70c";t["default"]=z}}]);