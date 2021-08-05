import test from 'blue-tape';
import regx from '../src/regx';

test('should compile to a regexp', async assert => {
	// flags on partials are ignored
	const open = /\/\*\*/i;
	const close = '\\*\\/';

	const expression = regx('gm')`
		// Match a non-recursive block comment
		(
			// Must be first thing on a line
			^[\t ]*

			${open} // Block opener

			// Capture content independently
			(
				// Match any character including newlines (non-greedy)
				[\s\S]*?
			)

			${close} // Block closer
		)

		// Grab trailing newlines and discard them
		[\r\n]*
	`;

	assert.same(expression, /(^[\t ]*\/\*\*([\s\S]*?)\*\/)[\r\n]*/gm);
});

if (process.browser) {
	test.onFinish(global.close);
}
