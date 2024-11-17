class Cookies {
    set(key, value) {
        localStorage.setItem(key, JSON.stringify(value)); 
    }

    get(key) {
        const value = localStorage.getItem(key);
        return value ? JSON.parse(value) : null; 
    }

    delete(key) {
        localStorage.removeItem(key);
    }
}

const cookies = new Cookies();
export default cookies;