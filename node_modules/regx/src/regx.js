const trailingComments = /\s+\/\/.*$/gm;
const surroundingWhitespace = /^\s+|\s+$/gm;
const literalNewlines = /[\r\n]/g;

export default function regx(flags) {
	return (strings, ...values) => {
		function toPattern(pattern, rawString, i) {
			let value = values[i];

			if (value === null || value === undefined) {
				return pattern + rawString;
			}

			if (value instanceof RegExp) {
				value = value.source;
			}

			return pattern + rawString + value;
		}

		const compiledPattern = strings.raw
			.reduce(toPattern, '')
			.replace(trailingComments, '')
			.replace(surroundingWhitespace, '')
			.replace(literalNewlines, '');

		return new RegExp(compiledPattern, flags);
	};
}
