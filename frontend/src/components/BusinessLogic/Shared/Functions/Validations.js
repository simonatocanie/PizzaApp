
export const isStringNotEmpty = (value) => value.trim() !== '';
export const isRequired = (value) => value > 0;
export const isBetweenInterval = (value) => (value > 0 && value < 50);