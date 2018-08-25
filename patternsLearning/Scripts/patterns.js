Vue.component('category', {
    template: `    
    <div>
            <h2 @click='selected = !selected;$root.showInfo = false' :title='description'>{{name}}</h2>
            <ul :class='{open:selected}'>
                <li v-for='art in article'><div :title='art.art_description' @click='$root.showArticle(art.art_name)'>{{art.art_name}}</div></li>
            </ul>
        </div>
    `,
    props: ['name', 'description','article'],
    data() {
        return {
            selected: false,
        }
    },
});

let app = new Vue({
    el: '.main',
    data: {
        showInfo: true,
        categories: [],
        info: '',
        article: false,
    },
    methods: {
        setCategories(obj) {
            this.info = obj.section.sec_description;
            let categories = obj.section.category;
            this.categories.push(...categories.splice(0, 3));
        },
        showArticle(name) {
            let data = new FormData();
            data.append('artName', name);
            fetch('/Patterns/Articles', { method: 'post', body: data }).then(r => r.text()).then(t => JSON.parse(t.replace(/&quot;/g, '\"'))).then(o => app.article = o.article[0]);
        }
    }
});

fetch('/Patterns/PatternPageStructure').then(r => r.text()).then(t => JSON.parse(t)).then(app.setCategories);