
export const getClassesFromProps = (className, classes) => {
    let classList = '';

    if (className != null) {
        const classesSplit = className.split(' ');
        classesSplit.map(item => classList += classes[item] + ' ')
    }

    return classList;
}