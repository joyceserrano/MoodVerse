import moment from 'moment';

class Cookies {
    set(key, value, options = {}) {
        let cookieString = `${encodeURIComponent(key)}=${encodeURIComponent(JSON.stringify(value))}`;
        
        if (options.expires) {
            if (options.expires instanceof Date) {
                cookieString += `; expires=${moment(options.expires).utc().format('ddd, DD MMM YYYY HH:mm:ss [GMT]')}`;
            } else {
                const expiryDate = moment().add(options.expires, 'days');
                cookieString += `; expires=${expiryDate.utc().format('ddd, DD MMM YYYY HH:mm:ss [GMT]')}`;
            }
        }

        if (options.path) cookieString += `; path=${options.path}`;
        if (options.domain) cookieString += `; domain=${options.domain}`;
        if (options.secure) cookieString += '; secure';
        if (options.sameSite) cookieString += `; samesite=${options.sameSite}`;

        document.cookie = cookieString;
    }

    get(key) {
        const cookies = document.cookie.split(';');
        for (let cookie of cookies) {
            const [cookieKey, cookieValue] = cookie.split('=').map(part => part.trim());
            if (decodeURIComponent(cookieKey) === key) {
                try {
                    return JSON.parse(decodeURIComponent(cookieValue));
                } catch {
                    return decodeURIComponent(cookieValue);
                }
            }
        }
        return null;
    }

    deleteAll() {
        const cookies = document.cookie.split(';');
        for (let cookie of cookies) {
            const [cookieKey] = cookie.split('=').map(part => part.trim());
            this.set(decodeURIComponent(cookieKey), '', { expires: moment(0).toDate() });
        }
    }
}

const cookies = new Cookies();
export default cookies;